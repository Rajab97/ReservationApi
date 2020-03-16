using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.RoomReservationDtos
{
    public class UpdateRoomReservationDto
    {
        [MaxLength(50, ErrorMessage = "Title must be smaller than 50 characters.")]
        public string Title { get; set; }


        /* [Required(ErrorMessage = "Member name must not be null.")]*/
        [MaxLength(500, ErrorMessage = "Description must be smaller than 25 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Reservation date must not be null.")]

        public DateTime ReservationDate { get; set; }




        [Required(ErrorMessage = "Member must not be null.")]

        public short MemberId { get; set; }


        [Required(ErrorMessage = "Room must not be null.")]
        public byte MeetingRoomId { get; set; }

        [Required(ErrorMessage = "Time must be selected.")]
        public byte TimeId { get; set; }
    }
}
