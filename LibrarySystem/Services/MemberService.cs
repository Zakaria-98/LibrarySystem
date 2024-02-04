using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class MemberService:IMemberService
    {
        private ApplicationDbContext _context;
        public MemberService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Member> AddMember(MemberDto dto)
        {
            var member = new Member { Name = dto.Name };
            _context.Members.AddAsync(member);
            _context.SaveChanges();
            return member;
        }

        public async Task<Member> DeleteMember(int id)
        {
            var member = await _context.Members.SingleOrDefaultAsync(member => member.Id == id);


            _context.Remove(member);
            _context.SaveChanges();
            return member;
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var members = await _context.Members.Select(g => new Member
            {
                Name = g.Name,
                Id = g.Id


            })
            .ToListAsync(); ;
            return members;
        }

        public async Task<Member> GetMembersById(int id)
        {
            var member = await _context.Members.Where(member => member.Id == id).Select(g => new Member
            {
                Name = g.Name,
                Id = g.Id,

            })
             .SingleOrDefaultAsync();

            return member;
        }

        public async Task<Member> UpdateMember(int id, MemberDto dto)
        {
            var member = await _context.Members.SingleOrDefaultAsync(member => member.Id == id);

            
            member.Name = dto.Name;
            _context.Update(member);
            _context.SaveChanges();
            return member;
        }
    }
}
