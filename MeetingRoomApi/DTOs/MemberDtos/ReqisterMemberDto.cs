using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.MemberDtos
{
    public class ReqisterMemberDto
    {
        [Required(ErrorMessage = "Member name must not be null.")]
        [MaxLength(25, ErrorMessage = "Member name must be smaller than 25 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Member surname must not be null.")]
        [MaxLength(25, ErrorMessage = "Member surname must be smaller than 25 characters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Username must not be null.")]
        [MaxLength(25, ErrorMessage = "Username must be smaller than 25 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must not be null.")]
        [MaxLength(25, ErrorMessage = "Password must be smaller than 25 characters.")]
        public string Password { get; set; }

        [EmailAddress]
        [MaxLength(25)]
        public string Email { get; set; }

        [MaxLength(7)]
        public string Color { get; set; }
    }
}
