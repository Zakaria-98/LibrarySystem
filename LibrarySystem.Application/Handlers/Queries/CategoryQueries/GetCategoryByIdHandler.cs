using LibrarySystem.Models;
using LibrarySystem.Queries.CategoryQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.CategoryQueries
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetCategoryByIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitofwork.Categories.GetByIdAsync(request.Id);
            if (category == null)
                return null;

            return category;
        }
    }
}
