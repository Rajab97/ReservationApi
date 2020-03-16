using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public interface IUserRoleService : IBaseService
    {
        Task<UserRole> Create(UserRole userRole);
        Task<Role> GetRole(int userRoleId);
    }
}
