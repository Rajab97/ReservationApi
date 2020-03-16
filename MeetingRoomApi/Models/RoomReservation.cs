using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Models
{
    [Table("RoomReservations")]
    public class RoomReservation
    {
        [Key]
        [Column("RoomReservation_Id")]
        public int Id { get; set; }


        [MaxLength(50, ErrorMessage = "Title must be smaller than 50 characters.")]
        public string Title { get; set; }


        /* [Required(ErrorMessage = "Member name must not be null.")]*/
        [MaxLength(500, ErrorMessage = "Description must be smaller than 25 characters.")]
        public string Description { get; set; }

        [Required( ErrorMessage ="Reservation date must not be null.")]
        [Column(TypeName = "date")]
        public DateTime ReservationDate { get; set; }


   /*     public bool IsActive { get; set; }*/

        [Required(ErrorMessage = "Member must not be null.")]
        [Column("Member_Id")]
        public short MemberId { get; set; }
        public Member Member { get; set; }

        [Required(ErrorMessage = "Room must not be null.")]
        [Column("MeetingRoom_Id")]
        public byte MeetingRoomId { get; set; }
        public MeetingRoom MeetingRoom { get; set; }

        [Required(ErrorMessage = "Time must be selected.")]
        [Column("Time_Id")]
        public short TimeId { get; set; }
        public Time Time { get; set; }



    }
}
