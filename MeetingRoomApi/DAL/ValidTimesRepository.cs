using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DAL
{
    public class ValidTimesRepository : BaseRepository , IValidTimesRepository
    {
        public ValidTimesRepository(MeetingRoomDbContext context) : base(context) { }

        public IQueryable<Time> GetAllValidTimes()
        {
            return _context.ValidTimes;
        }

        public async Task<Time> GetValidTime(int Id)
        {
            return await _context.ValidTimes.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<Time> GetValidTime(TimeSpan startTime)
        {
            return await _context.ValidTimes.FirstOrDefaultAsync(m => m.StartTime == startTime);
        }

        public async Task<Time> GetValidTime(TimeSpan startTime, TimeSpan endTime)
        {
            return await _context.ValidTimes.FirstOrDefaultAsync(m => m.StartTime == startTime && m.EndTime == endTime);
        }
    }
}
