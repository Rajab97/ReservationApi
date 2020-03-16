using MeetingRoomApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingRoomApi.Repositories
{
    public interface IMemberRepository : IBaseRepository
    {
        IQueryable<Member> GetAllMembers();

        Task<Member> GetMember(short Id);
        Task<Member> GetMember(string userName);
        Task<Member> Create(Member obj);
        Task<Member> Update(short Id, Member obj);

        Task Delete(short Id);

    }
}
