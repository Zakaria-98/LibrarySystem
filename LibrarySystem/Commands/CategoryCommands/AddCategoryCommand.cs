using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.CategoryCommands
{
    public class AddCategoryCommand: IRequest<Category>
    {
        public Category category;

        public AddCategoryCommand(Category category)
        {
            this.category = category;

        }
    }
}
