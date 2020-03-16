using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public interface IRoleService
    {
        
        Task<bool> RoleExist(string roleName);
        Task<Role> GetRole(string roleName);
        Task<Role> GetRole(short roleId);
    }
}
