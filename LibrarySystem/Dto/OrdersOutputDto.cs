using LibrarySystem.Models;

namespace LibrarySystem.Dto
{
    public class OrdersOutputDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime RestorationBeforeDate { get; set; }

        public int MemberId { get; set; }

        public string MemberName { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int BookQuantity { get; set; }

        public DateTime? RestorationDate { get; set; }

    }
}
