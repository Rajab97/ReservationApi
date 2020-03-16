using AutoMapper;
using MeetingRoomApi.DTOs.MemberDtos;
using MeetingRoomApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingRoomApi.DAL.EncryptionHelper;
using MeetingRoomApi.Models;
using MeetingRoomApi.Helpers;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace MeetingRoomApi.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMemberService _memberService;
        private readonly IRoleService _roleServicey;
        private readonly IUserRoleService _userRoleoleService;
        private readonly IHttpContextAccessor _httpContext;

        public AuthService(IMapper mapper, IMemberRepository memberRepository , IMemberService memberService,IRoleService roleService,IUserRoleService userRoleService , IHttpContextAccessor httpContext) : base(mapper,memberRepository) 
        {
            _memberRepository = memberRepository;
            _memberService = memberService;
            _roleServicey = roleService;
            _userRoleoleService = userRoleService;
            _httpContext = httpContext;
        }

        public async Task<string> Role(Member member)
        {
            string role = "";
            foreach (UserRole item in await _memberService.GetRolesFoMember(member.Id))
            {
                Role current = await _roleServicey.GetRole(item.RoleId);
                if (current.Name == Roles.Administrator)
                {
                    role += current.Name + " ";
                }
            }
            return role;
        }

        public async Task<Member> Login(LoginMemberDto loginMemberDto)
        {
            Member member = await _memberRepository.GetMember(loginMemberDto.UserName);
            if (member == null)
                return null;
            if (!member.Password.DecryptTextWithBCrypt(loginMemberDto.Password))
                return null;

            return member;
        }

        public async Task<bool> MemberExist(string username)
        {
            if (await _memberRepository.GetAllMembers().AnyAsync(m => m.UserName.ToLower() == username.ToLower().Trim()))
                return true;
            return false;
        }

        public async Task<Member> Reqister(ReqisterMemberDto reqisterMemberDto,string roleName)
        {
            if (!await _roleServicey.RoleExist(roleName))
                return null;

            Member member = _mapper.Map<Member>(reqisterMemberDto);
            member.Password = reqisterMemberDto.Password.EncryptWithBCrypt();
            member = await _memberRepository.Create(member);
            //role for member
            UserRole userRole = new UserRole()
            {
                Member = member,
                Role = await _roleServicey.GetRole(roleName)
            };


            //Adding UserRoleToDatabase UserRoleService ve UserRoleRepository Yazilmalidi.
            await _userRoleoleService.Create(userRole);
            reqisterMemberDto.Password = member.Password;
            return member;
        }

     
    }
}
