using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Models
{
    public class Role
    {
        [Key]
        public byte Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }
    }
}
