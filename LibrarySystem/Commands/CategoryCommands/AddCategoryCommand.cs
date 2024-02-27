using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.CategoryCommands
{
    public class AddCategoryCommand: IRequest<Category>
    {
        public string Name { get; set; }


    }
}
