using LibrarySystem.Commands.MemberCommands;

namespace LibrarySystem.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Member()
        {

        }
        public Member(AddMemberCommand addMemberCommand)
        {
            this.Name = addMemberCommand.Name;
        }

        public Member(UpdateMemberCommand updateMemberCommand)
        {
            this.Name = updateMemberCommand.Name;   

        }
    }
}
