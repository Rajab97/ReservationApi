using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DAL
{
    public class RoleRepository : BaseRepository ,IRoleRepository
    {
        public RoleRepository(MeetingRoomDbContext contex) : base(contex) { }

        public IQueryable<Role> GetAllRoles()
        {
           return _context.Roles;
        }

        public async Task<Role> GetRole(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(m => m.Name == roleName);
        }
    }
}
