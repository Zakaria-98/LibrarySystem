using LibrarySystem.Models;
using MediatR;
using LibrarySystem.Dto;

namespace LibrarySystem.Queries.OrderQueries
{
    public class GetOrderslateQuery : IRequest<IEnumerable<DisplayOutput>>
    {
    }
}
