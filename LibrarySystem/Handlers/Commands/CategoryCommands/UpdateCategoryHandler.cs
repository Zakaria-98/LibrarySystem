using LibrarySystem.Models;
using LibrarySystem.Commands.CategoryCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.CategoryCommands
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly IUnitOfWork _unitofwork;

        public UpdateCategoryHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            _unitofwork.Categories.Update(request.category);
            _unitofwork.Complete();

            return request.category;
        }
    }
}
