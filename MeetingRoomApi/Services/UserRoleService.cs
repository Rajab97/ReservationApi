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
    public class UserRoleService : BaseService , IUserRoleService
    {

        private readonly IUserRoleRepository _repository;
        public UserRoleService(IMapper mapper, IUserRoleRepository userRoleRepository) : base(mapper, userRoleRepository) 
        {
            _repository = userRoleRepository;
        }

        public async Task<UserRole> Create(UserRole userRole)
        {
            await _repository.AddAsync(userRole);
            return userRole;
        }

        public async Task<Role> GetRole(int userRoleId)
        {
            UserRole currentUserRole = await _repository.GetAllUserRoles().Include(m => m.Role).FirstOrDefaultAsync(m => m.Id == userRoleId);
            return currentUserRole.Role;
        }
    }
}
