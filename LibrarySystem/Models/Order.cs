using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; } 

        public DateTime RestorationDate { get; set; }

        public int MemberId { get; set; }

        public Member   Member { get; set; }

       // public ICollection<Book> Books { get; set; }
        public List <Item> Items { get; set; }

        
        public int? RestorationId { get; set; }

        public Restoration Restoration { get; set; }


    }
}
