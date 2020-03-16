using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Models
{
    [Table("Members")]
    public class Member
    {

        [Key]
        [Column("Member_Id")]
        public short Id { get; set; }


        [Required(ErrorMessage = "Member name must not be null.")]
        [MaxLength(25 , ErrorMessage = "Member name must be smaller than 25 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Member surname must not be null.")]
        [MaxLength(25, ErrorMessage = "Member surname must be smaller than 25 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Username must not be null.")]
        [MaxLength(25, ErrorMessage = "Username must be smaller than 25 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must not be null.")]
        [MaxLength(300, ErrorMessage = "Password must be smaller than 300 characters.")]
        public string Password { get; set; }

        [MaxLength(25)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(15)]
        public string ReservationColorCode { get; set; }

        public ICollection<RoomReservation> RoomReservations { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
