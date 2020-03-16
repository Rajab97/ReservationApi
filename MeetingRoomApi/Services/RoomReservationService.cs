using AutoMapper;
using MeetingRoomApi.DTOs.RoomReservationDtos;
using MeetingRoomApi.Exceptions;
using MeetingRoomApi.Helpers;
using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using MeetingRoomApi.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public class RoomReservationService : BaseService, IRoomReservationService
    {
        private readonly IMemberService _memberService;
        private readonly IRoleService _roleService;
        private readonly ISecurityContext _securityContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRoomReservationRepository _reservationRepository;
        private readonly ICalendarService _calendarService;

        public RoomReservationService(IRoomReservationRepository reservationRepository,ICalendarService calendarService,IMemberService memberService ,IRoleService roleService, ISecurityContext securityContext,IMapper mapper,IHttpContextAccessor httpContextAccessor) : base(mapper,reservationRepository) {
            this._memberService = memberService;
            this._roleService = roleService;
            this._securityContext = securityContext;
            this._httpContextAccessor = httpContextAccessor;
            this._reservationRepository = reservationRepository;
            this._calendarService = calendarService;
        }
        private async Task FillSecurityContext()
        {
            short userId = Convert.ToInt16(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _securityContext.IsAdministrator = await IsAdmin(userId);
            _securityContext.Member = await _memberService.GetMember(userId);
          

        }
        private async Task<bool> IsAdmin(short userId)
        {
            bool isAdmin = false;
            foreach (UserRole item in await _memberService.GetRolesFoMember(userId))
            {
                Role current = await _roleService.GetRole(item.RoleId);
                if (current.Name == Roles.Administrator)
                {
                    isAdmin = true;
                }
            }
            return isAdmin;
        }
        public async Task<RoomReservation> Create(CreateRoomReservationDto obj)
        { 
            RoomReservation roomReservation = _mapper.Map<RoomReservation>(obj);
            await _reservationRepository.Create(roomReservation);
            return roomReservation;
        }

        public async Task Delete(int Id)
        {
            await FillSecurityContext();
            RoomReservation roomReservation =await _reservationRepository.GetRoomReservation(Id);

            if (roomReservation == null)
                throw new NotFoundException("Resrvation is not found.");

        
            if (_securityContext.IsAdministrator || _securityContext.Member.Id == roomReservation.MemberId)
                await _reservationRepository.Delete(Id);
            else
                throw new ForbiddenException("You don't have acces for deleting this reservation.");

   
        }

        public IQueryable<RoomReservation> GetAllRoomReservations()
        {
            return  _reservationRepository.GetAllRoomReservations().Include(m => m.Time).Include(m=>m.Member).Include(m=>m.MeetingRoom);
        }
    
        public async Task<RoomReservation> Update(int Id ,UpdateRoomReservationDto obj)
        {
            await FillSecurityContext();
            var roomReservation = await _reservationRepository.GetRoomReservation(Id);
            if (roomReservation == null)
                throw new NotFoundException("Reservation is not found.");

            if (_securityContext.IsAdministrator)
            {
                roomReservation.MemberId = obj.MemberId;
            }
            roomReservation.MeetingRoomId = obj.MeetingRoomId;
            roomReservation.TimeId = obj.TimeId;
            roomReservation.ReservationDate = obj.ReservationDate;
            roomReservation.Title = obj.Title;
            roomReservation.Description = obj.Description;

            await _reservationRepository.Update(Id,roomReservation);

            return roomReservation;
        }

        public async Task<IQueryable<RoomReservation>> GetAllRoomReservationsOfCurrentUser()
        {
            await FillSecurityContext();
            var AllVisibleReservations = GetAllRoomReservations();

            if (!_securityContext.IsAdministrator)
                return AllVisibleReservations.Where(m => m.MemberId == _securityContext.Member.Id);
            return AllVisibleReservations;
        }

        public async Task<RoomReservation> GetRoomReservationOfCurrentUser(int Id)
        {
            IQueryable<RoomReservation> reservations = await GetAllRoomReservationsOfCurrentUser();
            return await reservations.FirstOrDefaultAsync(m => m.Id == Id) ;
        }

        public async Task<RoomReservation> GetRoomReservation(int Id)
        {
            return await GetAllRoomReservations().FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<bool> CheckIfDateExpired(DateTime date,short timeId)
        {
            Time reservationTime = await _calendarService.GetAllValidTimes().FirstOrDefaultAsync(m => m.Id == timeId);
            DateTime reservationDateTime = date.AddHours(reservationTime.StartTime.TotalHours).AddMinutes(reservationTime.StartTime.Minutes);
            DateTime currentDateTime = DateTime.Now;
            if (reservationDateTime < currentDateTime)
                return true;
           return false;
        }
    }
}
