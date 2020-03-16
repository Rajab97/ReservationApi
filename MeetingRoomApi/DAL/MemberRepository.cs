using MeetingRoomApi.Models;
using MeetingRoomApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MeetingRoomApi.DAL
{
    public class MemberRepository : BaseRepository, IMemberRepository
    {
        public MemberRepository(MeetingRoomDbContext contex) : base(contex) { }

        public async Task<Member> Create(Member obj)
        {
            await _context.Members.AddAsync(obj);
            return obj;
        }

        public async Task Delete(short Id)
        {
            Member member = await GetMember(Id);
            _context.Members.Remove(member);
        }

        public void Dispose()
        {
            Commit();
            _context.Dispose();
        }

        public IQueryable<Member> GetAllMembers()
        {
            return _context.Members;
        }

        public async Task<Member> GetMember(short Id)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<Member> GetMember(string userName)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.UserName == userName);
        }

        public async Task<Member> Update(short Id, Member obj)
        {
            Member member = await GetMember(Id);
            member.Name = obj.Name;
            member.Password = obj.Password;
            member.Surname = obj.Surname;
            member.UserName = obj.UserName;
            _context.Members.Update(member);
            return member;
        }
    }
}
