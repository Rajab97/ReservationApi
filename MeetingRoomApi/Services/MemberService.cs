using AutoMapper;
using MeetingRoomApi.DAL.EncryptionHelper;
using MeetingRoomApi.Helpers.EmailService;
using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IHttpContextAccessor _httpContext;

        public MemberService(IMapper mapper,IMemberRepository memberRepository,IHttpContextAccessor httpContext) :base(mapper,memberRepository)
        {
            _memberRepository = memberRepository;
            _httpContext = httpContext;
        }

      

        public async Task ChangePassword(string lastPassword, string newPassword)
        {
            short userId = Convert.ToInt16(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Member member = await _memberRepository.GetMember(userId);
            if (member == null)
                throw new UnauthorizedAccessException("User not found");
            if (!member.Password.DecryptTextWithBCrypt(lastPassword))
                throw new ArgumentException("Last password isn't correct");
            member.Password = newPassword.EncryptWithBCrypt();
            await _memberRepository.Update(userId, member);
            await _memberRepository.CommitAsync();
        }

        public async Task<Member> GetMember(short memberId)
        {
            return await _memberRepository.GetMember(memberId);
        }

        public IQueryable<Member> GetMembers()
        {
            return _memberRepository.GetAllMembers();
        }

        public async Task<ICollection<UserRole>> GetRolesFoMember(short id)
        {
            Member member = await _memberRepository.GetAllMembers().Include(m => m.UserRoles).FirstOrDefaultAsync(m => m.Id == id);
            return member.UserRoles;
        }

        public IQueryable<string> GetValidMembersEmails()
        {
            return GetMembers().Where(m => !String.IsNullOrEmpty(m.Email) && Message.CheckMail(m.Email)).Select(m => m.Email);
        }

        public async Task<Member> UpdateMember(short id,Member member)
        {
            Member currentMember = await _memberRepository.GetMember(id);
            if (currentMember == null)
                throw new UnauthorizedAccessException("Member doesn't exist");
            if (string.IsNullOrEmpty(member.ReservationColorCode))
                throw new ArgumentNullException("You must send any color value.");
            Regex regex = new Regex(@"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
            if (!regex.IsMatch(member.ReservationColorCode))
                throw new ArgumentException("Color is not in correct format.");
            member.ReservationColorCode = regex.Match(member.ReservationColorCode).Value;

            currentMember.Name = member.Name;
            currentMember.ReservationColorCode = member.ReservationColorCode;
            currentMember.Surname = member.Surname;
            currentMember.UserName = member.UserName;
            currentMember.Email = member.Email;
            await _memberRepository.Update(id, currentMember);
            await _memberRepository.CommitAsync();
            return member;
        }
    }
}
