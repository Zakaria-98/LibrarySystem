using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.CategoryCommands
{
    public class DeleteCategoryCommand: IRequest<Category>
    {

        public Category category;

        public DeleteCategoryCommand(Category category)
        {
            this.category = category;

        }
    }
}
