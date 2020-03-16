using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Repositories
{
    public interface IUserRoleRepository : IBaseRepository
    {
        Task<UserRole> AddAsync(UserRole obj);
        Task<UserRole> Update(int Id ,UserRole obj);

        void Remove(UserRole obj);
        IQueryable<UserRole> GetAllUserRoles();

        Task<UserRole> GetUserRole(int Id);
    }
}
