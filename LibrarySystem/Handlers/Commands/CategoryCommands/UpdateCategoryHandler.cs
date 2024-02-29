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
            var Category = await _unitofwork.Categories.GetByIdAsync(request.Id);
            if (Category == null)
                return null;

            var category = new Category(request);
            _unitofwork.Categories.Update(category);
            _unitofwork.Complete();

            return category;
        }
    }
}
