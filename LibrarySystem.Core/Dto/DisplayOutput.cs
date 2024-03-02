using LibrarySystem.Models;

namespace LibrarySystem.Dto
{
    public class DisplayOutput
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RestorationBeforeDate { get; set; }

        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public List<OrderItemsOutputDto> Items { get; set; }

        public DateTime? RestorationDate { get; set; }

    }
}
