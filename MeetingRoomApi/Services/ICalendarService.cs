using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public interface ICalendarService : IBaseService
    {
        IQueryable<Time> GetAllValidTimes();
    }
}
