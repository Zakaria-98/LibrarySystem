using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.CategoryCommands
{
    public class UpdateCategoryCommand:IRequest<Category>
    {
        public Category category;

        public UpdateCategoryCommand(Category category)
        {
            this.category = category;

        }
    }
}
