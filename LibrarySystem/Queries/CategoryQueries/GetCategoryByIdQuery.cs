using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery: IRequest<Category>
    {
       public int Id;
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
