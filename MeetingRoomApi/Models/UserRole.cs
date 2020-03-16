using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public short MemberId { get; set; }
        public Member Member { get; set; }
        public byte RoleId { get; set; }
        public Role Role { get; set; }
    }
}
