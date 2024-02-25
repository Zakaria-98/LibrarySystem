using LibrarySystem.Models;
using MediatR;
using LibrarySystem.Dto;

namespace LibrarySystem.Queries.OrderQueries
{
    public class GetOrdersbyOrderDateFilterQuery : IRequest<IEnumerable<DisplayOutput>>
    {
        public DateTime date1, date2;
        public GetOrdersbyOrderDateFilterQuery(DateTime date1, DateTime date2)
        {
            this.date1 = date1;
            this.date2 = date2;
        }
    }
}
