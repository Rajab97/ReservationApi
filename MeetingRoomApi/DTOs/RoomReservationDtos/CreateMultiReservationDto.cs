using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.RoomReservationDtos
{
    public class CreateMultiReservationDto
    {
        public short[] TimeIds { get; set; }
        public string Description { get; set; }
        public short MemberId { get; set; }
        public string Date { get; set; }
    }
}
