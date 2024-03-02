using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries.CategoryQueries
{
    public class GetAllCategoriesQuery:IRequest<IEnumerable<Category>>
    {
    }
}
