using LibrarySystem.Dto;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IMemberService
    {


         Task<IEnumerable<Member>> GetAllMembers();

        Task<Member> GetMembersById(int id);

        Task<Member> AddMember(Member member);

        Member UpdateMember(Member member);

        Member DeleteMember(Member member);

    }
}
