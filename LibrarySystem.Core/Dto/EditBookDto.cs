namespace LibrarySystem.Dto
{
    public class EditBookDto
    {
        public string Title { get; set; }
        public int AllQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int CategoryId { get; set; }

    }
}
