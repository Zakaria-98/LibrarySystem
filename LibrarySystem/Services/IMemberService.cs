using LibrarySystem.Dto;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IMemberService
    {


         Task<IEnumerable<Member>> GetAllMembers();

        Task<Member> GetMembersById(int id);

        Task<Member> AddMember(Member member);

        Task<Member> UpdateMember(Member member);

        Task<Member> DeleteMember(Member member);

    }
}
