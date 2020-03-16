using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.RoomReservationDtos
{
    public class GetRoomReservationDto
    {
        public int Id { get; set; }


        public string Title { get; set; }


        /* [Required(ErrorMessage = "Member name must not be null.")]*/
        public string Description { get; set; }

        public DateTime ReservationDate { get; set; }



        public short MemberId { get; set; }
        public string MemberName { get; set; }
        public string BackColor { get; set; }
        public byte MeetingRoomId { get; set; }

        public string Time { get; set; }
        public short TimeId { get; set; }

    }
}
