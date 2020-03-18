using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public interface IMemberService :IBaseService
    {
        Task<ICollection<UserRole>> GetRolesFoMember(short id);
        IQueryable<Member> GetMembers();
        Task<Member> GetMember(short memberId);
        IQueryable<string> GetValidMembersEmails();
        Task<Member> UpdateMember(short Id,Member member);
        Task ChangePassword(string lastPassword, string newPassword);
        Task<bool> IsAdmin(short userId);
   
    }
}
