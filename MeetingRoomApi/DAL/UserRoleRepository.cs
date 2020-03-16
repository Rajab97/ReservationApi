using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.DAL
{
    public class UserRoleRepository : BaseRepository, IUserRoleRepository
    {

        public UserRoleRepository(MeetingRoomDbContext meetingRoomDbContext) : base(meetingRoomDbContext)
        {

        }

        public async Task<UserRole> AddAsync(UserRole obj)
        {
            await _context.AddAsync(obj);
            return obj;
        }

        public IQueryable<UserRole> GetAllUserRoles()
        {
            return _context.UserRoles;
        }

        public async Task<UserRole> GetUserRole(int Id)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public void Remove(UserRole obj)
        {
            _context.UserRoles.Remove(obj);
        }

        public async Task<UserRole> Update(int Id,UserRole obj)
        {
            UserRole userRole = await GetUserRole(Id);
            userRole.MemberId = obj.MemberId;
            userRole.RoleId = obj.RoleId;
            _context.UserRoles.Update(userRole);
            return userRole;
        }
    }
}
