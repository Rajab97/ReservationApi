using AutoMapper;
using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public class RoleService:BaseService,IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IMapper mapper, IRoleRepository roleRepository) : base(mapper, roleRepository) 
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetRole(string roleName)
        {
            return await _roleRepository.GetRole(roleName);
        }

        public async Task<Role> GetRole(short roleId)
        {
            return await _roleRepository.GetAllRoles().FirstOrDefaultAsync(m => m.Id == roleId);
        }

        public async Task<bool> RoleExist(string roleName)
        {
            if (await _roleRepository.GetAllRoles().AnyAsync(m => m.Name == roleName))
                return true;
            return false;
        }
    }
}
