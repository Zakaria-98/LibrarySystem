using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class MemberService:IMemberService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        public MemberService(ApplicationDbContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;
        }

        public async Task<Member> AddMember(Member member)
        {
            var Member = await _unitofwork.Members.AddAsync(member);
            _unitofwork.Complete();
            return Member;
        }

        public Member DeleteMember(Member member)
        {
            _unitofwork.Members.Delete(member);
            _unitofwork.Complete();

            return member;
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var Members = await _unitofwork.Members.GetAllAsync();
            return Members;
        }

        public async Task<Member> GetMembersById(int id)
        {
            var Member = await _unitofwork.Members.GetByIdAsync(id);
            if (Member == null)
                return null;

            return Member;
        }

        public  Member UpdateMember(Member member)
        {

            _unitofwork.Members.Update(member);
            _unitofwork.Complete();

            return member;
        }
    }
}
