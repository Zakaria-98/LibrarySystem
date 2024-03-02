using LibrarySystem.Models;
using LibrarySystem.Queries.CategoryQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.CategoryQueries
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetAllCategoriesHandler( IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitofwork.Categories.GetAllAsync();
            return categories;

        }
    }
}
