namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AllQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Order> Orders { get; set; }

        public List<Item> Items { get; set; }
    }
}
