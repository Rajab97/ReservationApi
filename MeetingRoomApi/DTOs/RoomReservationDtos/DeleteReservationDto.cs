using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.RoomReservationDtos
{
    public class DeleteReservationDto
    {
        public int ReservationId { get; set; }
        public short TimeId { get; set; }
    }
}
