using LibrarySystem.Commands.CategoryCommands;

namespace LibrarySystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public Category()
        {

        }

        public Category(AddCategoryCommand addCategoryCommand)
        {
            this.Name=addCategoryCommand.Name;

        }

        public Category(UpdateCategoryCommand updateCategoryCommand)
        {
            this.Name = updateCategoryCommand.Name;

        }
    }
}
