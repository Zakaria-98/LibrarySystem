using LibrarySystem.Models;
using MediatR;
using LibrarySystem.Dto;

namespace LibrarySystem.Queries.OrderQueries
{
    public class GetOrdersbyRestorationDateFilterQuery : IRequest<IEnumerable<DisplayOutput>>
    {
        public DateTime date1, date2;
        public GetOrdersbyRestorationDateFilterQuery(DateTime date1, DateTime date2)
        {
            this.date1 = date1;
            this.date2 = date2;
        }
    }
}
