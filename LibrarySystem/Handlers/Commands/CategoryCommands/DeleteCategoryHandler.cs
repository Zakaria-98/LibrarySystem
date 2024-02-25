using LibrarySystem.Models;
using LibrarySystem.Commands.CategoryCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.CategoryCommands
{

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        private readonly IUnitOfWork _unitofwork;

        public DeleteCategoryHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Category> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _unitofwork.Categories.Delete(request.category);
            _unitofwork.Complete();

            return request.category;
        }
    }
}
