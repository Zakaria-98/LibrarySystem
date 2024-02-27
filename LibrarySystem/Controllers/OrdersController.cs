using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using LibrarySystem.Queries.OrderQueries;
using LibrarySystem.Commands.OrderCommands;
using LibrarySystem.Queries.BookQueries;
using LibrarySystem.Queries.MemberQueries;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;


        public OrdersController( IMediator mediator)
        {

            _mediator = mediator;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllOrders()
        {

            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        

        [HttpGet("OrderbyId")]

        public async Task<IActionResult> GetOrdersByOrderId([FromQuery] int Orderid)
        {
            var query = new GetOrdersByOrderIdQuery(Orderid);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound("Wrong Id:" + Orderid);
            return Ok(result);



        }


        [HttpGet("OrdersExceedRestorationDate")]

        public async Task<IActionResult> GetOrderslate()
        {

            var query = new GetOrderslateQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpGet("OrderbyOrderDateFilter")]

        public async Task<IActionResult> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2)
        {
            var query = new GetOrdersbyOrderDateFilterQuery(date1, date2);
            var result = await _mediator.Send(query);
            return Ok(result);


        }

        [HttpGet("OrderbyRestorationDateFilter")]

        public async Task<IActionResult> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2)
        {
            var query = new GetOrdersbyRestorationDateFilterQuery(date1, date2);
            var result = await _mediator.Send(query);
            return Ok(result);

        }


        [HttpGet("OrderbyMember")]

        public async Task<IActionResult> GetOrdersByMemberId([FromQuery] int MemberId)
        {
            var query = new GetOrdersByMemberIdQuery(MemberId);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound("Wrong Id: " + MemberId);
            return Ok(result);

        }

        

        [HttpGet("OrderbyBook")]

        public async Task<IActionResult> GetOrdersByBookId([FromQuery] int BookId)
        {
            var query = new GetOrdersByBookIdQuery(BookId);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound("Wrong Id: " + BookId);
            return Ok(result);



        }


        [HttpPost]
        public async Task<IActionResult> AddOrder( int MemberId , [FromBody] List<ItemsDto> Items)
        {
            var addOrderCommand = new AddOrderCommand();
            addOrderCommand.MemberId = MemberId; 
            addOrderCommand.Items=Items;
            var command = addOrderCommand;
            var result = await _mediator.Send(command);


            return Ok(result);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromQuery] EditOrderDto editOrder, [FromBody] List<ItemsDto> Items)
        {

            var command = new UpdateOrderCommand(id, editOrder, Items);
            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest(" wrong! please try again");
            else
                return Ok("Updated successfuly");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var command = new DeleteOrderCommand(id);
            var result = await _mediator.Send(command);
            if (!result)
                return BadRequest(" wrong! please try again");
            else
                return Ok("Removed successfuly");
        }

    }
}
