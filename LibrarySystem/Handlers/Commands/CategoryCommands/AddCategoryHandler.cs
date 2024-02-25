using LibrarySystem.Models;
using LibrarySystem.Commands.CategoryCommands;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Commands.CategoryCommands
{
    public class AddCategoryHandler:IRequestHandler<AddCategoryCommand,Category>
    {
        private readonly IUnitOfWork _unitofwork;

        public AddCategoryHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitofwork.Categories.AddAsync(request.category);
            _unitofwork.Complete();
            return result;
        }
    }
}
