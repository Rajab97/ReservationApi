using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.MemberDtos
{
    public class MemberDetailsDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }
        [EmailAddress]
        [MaxLength(25)]
        public string Email { get; set; }

        public string Color { get; set; }
    }
}
