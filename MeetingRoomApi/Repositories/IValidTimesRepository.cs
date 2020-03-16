using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Repositories
{
    public interface IValidTimesRepository :  IBaseRepository
    {
        IQueryable<Time> GetAllValidTimes();
        Task<Time> GetValidTime(int Id);
        Task<Time> GetValidTime(TimeSpan startTime);
        Task<Time> GetValidTime(TimeSpan startTime , TimeSpan endTime);
    }
}
