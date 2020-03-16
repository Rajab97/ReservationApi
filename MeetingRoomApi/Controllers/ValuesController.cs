using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingRoomApi.DAL;
using MeetingRoomApi.DTOs.RoomReservationDtos;
using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using MeetingRoomApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
    
        private readonly IRoomReservationService _roomReservationService;
        public ValuesController(IRoomReservationService roomReservationRepository)
        {
            _roomReservationService = roomReservationRepository;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            //CreateRoomReservationDto createRoomReservationDto = new CreateRoomReservationDto()
            //{
            //    Description = "First Description",
            //    Title = "First Title",
            //    MeetingRoomId = 1,
            //    TimeId = 2,
            //    MemberId = 2,
            //    ReservationDate = DateTime.Now
            //};
            //_roomReservationService.Create(createRoomReservationDto);
            RoomReservation reservation = await _roomReservationService.GetRoomReservation(1);
            return reservation.Time.ToString();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<string> Get(int id)
        {

            return "Yes";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
