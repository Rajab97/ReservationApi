using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeetingRoomApi.DTOs.RoomReservationDtos;
using MeetingRoomApi.Helpers;
using MeetingRoomApi.Helpers.EmailService;
using MeetingRoomApi.Models;
using MeetingRoomApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IRoomReservationService _roomReservationService;
        private readonly IMemberService _memberService;
        private readonly ICalendarService _calendarService;
        private readonly IUserRoleService _userRoleService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IEmailSender _emailSender;
        private readonly EmailConfiguration _configuration;

        public ReservationController(IRoomReservationService roomReservation,
            IMemberService memberService,
            ICalendarService calendarService,
            IUserRoleService userRoleService,
            IHttpContextAccessor httpContext ,
            IEmailSender emailSender,
            EmailConfiguration configuration) 
        {
            _roomReservationService = roomReservation;
            _memberService = memberService;
            _calendarService = calendarService;
            _userRoleService = userRoleService;
            _httpContext = httpContext;
            _emailSender = emailSender;
            _configuration = configuration;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMultiReservationDto reservationsDto)
        {
            DateTime GlobalDateTime = DateTime.Parse(reservationsDto.Date);
            Member member = await _memberService.GetMember(reservationsDto.MemberId);
            StringBuilder reservationTimes = new StringBuilder(String.Empty);
            List<Time> reservedTimes = new List<Time>();
             foreach (var timeId in reservationsDto.TimeIds)
            {
                if (!await _roomReservationService.CheckIfDateExpired(GlobalDateTime, timeId))
                {
                    CreateRoomReservationDto reservation = new CreateRoomReservationDto()
                    {
                        Description = reservationsDto.Description,
                        MeetingRoomId = 1,//Defaultnan goturemk lazimdi service yaranmalidi
                        MemberId = reservationsDto.MemberId,
                        TimeId = timeId,
                        ReservationDate = GlobalDateTime
                    };
                    Time time = await _calendarService.GetAllValidTimes().FirstOrDefaultAsync(m => m.Id == reservation.TimeId);
                    reservedTimes.Add(time);
                    
                    await _roomReservationService.Create(reservation);
                }
            }
            await _roomReservationService.CommitAsync();
            foreach (Time item in reservedTimes.OrderBy(m => m.StartTime))
            {
                reservationTimes.Append(item.StartTime + " - " + item.EndTime + "\n");
            }
            if (_configuration.Notify)
            {
                try
                {
                    Message message = new Message(_memberService.GetValidMembersEmails(),
                   "Meeting-Room: " + member.Name + " " + member.Surname + " rezervasiyasiya elave etdi.",
                   "Description: " + reservationsDto.Description + "\n"
                   + "Date " + reservationsDto.Date + "\n" +
                   reservationTimes.ToString());
                    await _emailSender.SendEmailAsync(message);
                }
                catch
                {

                }
            }
           
            
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            RoomReservation reservation = await _roomReservationService.GetRoomReservation(id);
            if (reservation != null && !await _roomReservationService.CheckIfDateExpired(reservation.ReservationDate, reservation.TimeId))
            {
                RoomReservation roomReservation = await _roomReservationService.GetAllRoomReservations().Include(m => m.Time).Include(m => m.Member).ThenInclude(u => u.UserRoles).FirstOrDefaultAsync(m => m.Id == id);
                await _roomReservationService.Delete(id);
                await _roomReservationService.CommitAsync();

                if (_configuration.Notify)
                {
                    try
                    {
                        Message message = new Message(
                      _memberService.GetValidMembersEmails(),
                      "Meeting-Room: " + roomReservation.Member.Name + " " + roomReservation.Member.Surname + " rezervasiyasini sildi.",
                      roomReservation.Description + "\n" + roomReservation.ReservationDate + " " + roomReservation.Time.StartTime + "-" + roomReservation.Time.EndTime);
                        await _emailSender.SendEmailAsync(message);
                    }
                    catch
                    {

                    }
                }
               
              
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("getReservation")]
        public IActionResult Get()
        {


            return Ok();
        }
    }
}