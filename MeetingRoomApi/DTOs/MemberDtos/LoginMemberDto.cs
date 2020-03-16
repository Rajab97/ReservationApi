using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.MemberDtos
{
    public class LoginMemberDto
    {
        [Required(ErrorMessage = "Username must not be null.")]
        [MaxLength(25, ErrorMessage = "Username must be smaller than 25 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password must not be null.")]
        [MaxLength(25, ErrorMessage = "Password must be smaller than 25 characters.")]
        public string Password { get; set; }

    }
}
