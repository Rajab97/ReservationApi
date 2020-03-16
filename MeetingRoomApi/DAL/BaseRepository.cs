using MeetingRoomApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DAL
{
    public class BaseRepository : IBaseRepository
    {
        protected readonly MeetingRoomDbContext _context;
        public BaseRepository(MeetingRoomDbContext contex)
        {
            _context = contex;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

      
     
    }
}
