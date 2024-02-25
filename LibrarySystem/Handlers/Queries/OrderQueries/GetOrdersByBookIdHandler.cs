using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersByBookIdHandler : IRequestHandler<GetOrdersByBookIdQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersByBookIdHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrdersByBookIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitofwork.Items.GetListAsync(
               o => o.BookId == request.BookId,
                o => new DisplayOutput
                {
                    Id = o.Order.Id,
                    MemberName = o.Order.Member.Name,
                    OrderDate = o.Order.OrderDate,
                    RestorationBeforeDate = o.Order.RestorationDate,
                    RestorationDate = o.Order.Restoration.RestorationDate,
                    Items = o.Order.Items.Select(i => new OrderItemsOutputDto
                    {
                        BookId = i.BookId,
                        BookName = i.Book.Title,
                        BookQuantity = i.BookQuantity
                    }).ToList()

                });


            return orders;
        }
    }
}
