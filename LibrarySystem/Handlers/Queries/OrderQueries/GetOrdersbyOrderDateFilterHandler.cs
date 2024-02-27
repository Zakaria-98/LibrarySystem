﻿using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.OrderQueries
{
    public class GetOrdersbyOrderDateFilterHandler : IRequestHandler<GetOrdersbyOrderDateFilterQuery, IEnumerable<DisplayOutput>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetOrdersbyOrderDateFilterHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<DisplayOutput>> Handle(GetOrdersbyOrderDateFilterQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitofwork.Orders.GetListAsync(
                o => (DateTime.Compare(request.date1, o.OrderDate) <= 0 && DateTime.Compare(request.date2, o.OrderDate) >= 0),
                o => new DisplayOutput
                {
                    Id = o.Id,
                    MemberId = o.MemberId,
                    MemberName = o.Member.Name,
                    OrderDate = o.OrderDate,
                    RestorationBeforeDate = o.RestorationDate,
                    RestorationDate = o.Restoration.RestorationDate,
                    Items = o.Items.Select(i => new OrderItemsOutputDto
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