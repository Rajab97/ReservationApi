using MeetingRoomApi.DTOs.MemberDtos;
using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Services
{
    public interface IAuthService:IBaseService
    {
        Task<Member> Login(LoginMemberDto loginMemberDto);
        Task<Member> Reqister(ReqisterMemberDto reqisterMemberDto,string role);
   
        Task<bool> MemberExist(string username);
        Task<string> Role(Member member);
    }
}
