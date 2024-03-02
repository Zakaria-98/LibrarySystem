using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.CategoryCommands
{
    public class UpdateCategoryCommand:IRequest<Category>
    {
        public string Name { get; set; }

        public int Id { get; set; }

    }
}
