using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DTOs.ValidTimes
{
    public class ValidTimeViewDto
    {
        public short Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
