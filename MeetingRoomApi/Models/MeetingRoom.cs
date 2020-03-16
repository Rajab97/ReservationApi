using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Models
{

    [Table("MeetingRooms")]
    public class MeetingRoom
    {
        [Key]
        [Column("MeetingRoom_Id")]
        public byte Id { get; set; }

        [Required(ErrorMessage = "Room name must not be null.")]
        [MaxLength(50,ErrorMessage = "Room name must be smaller than 50 characters.")]
        public string RoomName { get; set; }

        public ICollection<RoomReservation> RoomReservations { get; set; }
    }
}
