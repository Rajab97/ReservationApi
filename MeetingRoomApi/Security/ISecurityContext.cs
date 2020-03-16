using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Security
{
    public class ISecurityContext
    {
        public Member Member { get; set; }

        public bool IsAdministrator { get; set; }
    }
}
