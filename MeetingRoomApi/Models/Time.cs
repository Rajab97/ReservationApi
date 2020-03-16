using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Models
{
    [Table("ValidRoomTimes")]
    public class Time
    {
        [Key]
        [Column("ValidRoomTime_Id")]
        public short Id { get; set; }

        [Required(ErrorMessage = "Start time must not be null.")]
        [Column(TypeName = "time(0)")]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End time must not be null.")]
        [Column(TypeName = "time(0)")]
        public TimeSpan EndTime { get; set; }

        public ICollection<RoomReservation> RoomReservations { get; set; }
    }
}
