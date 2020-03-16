using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Repositories
{
    public interface IRoleRepository : IBaseRepository
    {
        IQueryable<Role> GetAllRoles();

        Task<Role> GetRole(string roleName);

    }
}
