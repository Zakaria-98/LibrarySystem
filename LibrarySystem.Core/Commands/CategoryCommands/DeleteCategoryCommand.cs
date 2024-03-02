using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Commands.CategoryCommands
{
    public class DeleteCategoryCommand: IRequest<Category>
    {

        public int Id;

        public DeleteCategoryCommand(int id)
        {
            this.Id = id;


        }
    }
}
