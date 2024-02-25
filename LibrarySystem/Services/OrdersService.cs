using LibrarySystem.Commands.OrderCommands;
using LibrarySystem.Queries.OrderQueries;

using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class OrdersService : IOrdersService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;
        private readonly IMediator _mediator;


        public OrdersService(ApplicationDbContext context, IUnitOfWork unitofwork, IMediator mediator)
        {

            _context = context;
            _unitofwork = unitofwork;
            _mediator = mediator;
        }
        public async Task<IEnumerable<DisplayOutput>> GetAllOrders()
        {

            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return result;


        }


        public async Task<DisplayOutput> GetOrdersByOrderId(int Orderid)
        {


            var query = new GetOrdersByOrderIdQuery(Orderid);
            var result = await _mediator.Send(query);
            return result;


        }

        public async Task<IEnumerable<DisplayOutput>> GetOrderslate()
        {

            var query = new GetOrderslateQuery();
            var result = await _mediator.Send(query);
            return result;




        }


        public async Task<IEnumerable<DisplayOutput>> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2)
        {


            var query = new GetOrdersbyOrderDateFilterQuery(date1,date2);
            var result = await _mediator.Send(query);
            return result;



        }

        public async Task<IEnumerable<DisplayOutput>> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2)
        {
            var query = new GetOrdersbyRestorationDateFilterQuery(date1, date2);
            var result = await _mediator.Send(query);
            return result;



        }

        public async Task<IEnumerable<DisplayOutput>> GetOrdersByMemberId(int MemberId)
        {
            var query = new GetOrdersByMemberIdQuery(MemberId);
            var result = await _mediator.Send(query);
            return result;




        }

        public async Task<IEnumerable<DisplayOutput>> GetOrdersByBookId(int BookId)
        {

            var query = new GetOrdersByBookIdQuery(BookId);
            var result = await _mediator.Send(query);
            return result;




        }

        public async Task<string> AddOrder(OrderDto dto, List<ItemsDto> dto2)
        {
 

            var command = new AddOrderCommand(dto,dto2);
            var result = await _mediator.Send(command);


            return result;

        }


        public async Task<bool> IsOrderRestored(int id)
        {



            var command = new IsOrderRestoredCommands(id);
            var result = await _mediator.Send(command);


            return result;

        }
        
        public async Task<bool> UpdateOrder(int id, EditOrderDto dto,  List<ItemsDto> dto2)
        {


            var command = new UpdateOrderCommand(id,dto, dto2);
            var result = await _mediator.Send(command);


            return result;


        }


        public async Task<bool> DeleteOrder(int id)
        {



            var command = new DeleteOrderCommand(id);
            var result = await _mediator.Send(command);


            return result;

        }



    }
    }
