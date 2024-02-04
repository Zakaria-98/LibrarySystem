using LibrarySystem.Dto;
using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface IMemberService
    {


         Task<IEnumerable<Member>> GetAllMembers();

        Task<Member> GetMembersById(int id);

        Task<Member> AddMember( MemberDto dto);

        Task<Member> UpdateMember(int id, MemberDto dto);

        Task<Member> DeleteMember(int id);

    }
}
