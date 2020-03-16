using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MeetingRoomApi.DTOs.RoomReservationDtos;
using MeetingRoomApi.DTOs.ValidTimes;
using MeetingRoomApi.Repositories;
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
    public class CalendarManipulationController : ControllerBase
    {
        private readonly ICalendarService _calendarService;
        private readonly IRoomReservationService _roomReservationService;
        private readonly IMapper _mapper;

        public CalendarManipulationController(ICalendarService calendarService,IRoomReservationService roomReservationService, IMapper mapper)
        {
            this._calendarService = calendarService;
            this._roomReservationService = roomReservationService;
            this._mapper = mapper;
        }
        [HttpGet("validTimes")]
        public ActionResult<List<ValidTimeViewDto>> GetAllValidTimes()
        {
            List<ValidTimeViewDto> dtos = new List<ValidTimeViewDto>(); 
            foreach (var item in _calendarService.GetAllValidTimes().OrderBy(m => m.StartTime))
            {
                dtos.Add(_mapper.Map<ValidTimeViewDto>(item));
            }
            return dtos;
        }
        [HttpGet("GetReservations/{year?}/{month?}")]
        public ActionResult<List<GetRoomReservationDto>> GetReservations(int? year, int? month)
        {
            DateTime currentDate = DateTime.Now;
            var filteredData = _roomReservationService.GetAllRoomReservations().OrderBy(m => m.ReservationDate).ThenBy(m => m.Time.StartTime).ToList();
            if (year == null && month == null)
            {
                filteredData = filteredData.Where(m => m.ReservationDate.Year == currentDate.Year && m.ReservationDate.Month == currentDate.Month).ToList();
            }
            else if (year != null && month != null)
            {
                filteredData = filteredData.Where(m => m.ReservationDate.Year == year && m.ReservationDate.Month == month).ToList();
            }
            else if(year != null)
            {
                filteredData = filteredData.Where(m => m.ReservationDate.Year == year).ToList();
            }
           
            List<GetRoomReservationDto> result = new List<GetRoomReservationDto>();
            foreach (var item in filteredData)
            {
               result.Add(_mapper.Map<GetRoomReservationDto>(item));
            }
            return result;
        }
    }
}