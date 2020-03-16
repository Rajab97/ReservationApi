using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.MemberDtos
{
    public class ChangePasswordDto
    {
        public string LastPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
