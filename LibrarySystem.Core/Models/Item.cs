namespace LibrarySystem.Models
{
    public class Item
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public int BookQuantity { get; set; }


    }
}
