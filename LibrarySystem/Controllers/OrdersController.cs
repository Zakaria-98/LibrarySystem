using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        private readonly IOrdersService _ordersService;
        private readonly IBooksServices _booksService;

        public OrdersController( IOrdersService ordersService, IMemberService memberService, IBooksServices booksService)
        {
            _ordersService = ordersService;
            _memberService = memberService;
            _booksService = booksService;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _ordersService.GetAllOrders();
            return Ok(orders);

        }

        

        [HttpGet("OrderbyId")]

        public async Task<IActionResult> GetOrdersByOrderId([FromQuery] int Orderid)
        {

            var order = await _ordersService.GetOrdersByOrderId(Orderid);

            if (order == null)
                return NotFound("Wrong Id:" + Orderid);

            return Ok(order);

        }


        [HttpGet("OrdersExceedRestorationDate")]

        public async Task<IActionResult> GetOrderslate()
        {

            var order = await _ordersService.GetOrderslate();


            return Ok(order);
        }

        [HttpGet("OrderbyOrderDateFilter")]

        public async Task<IActionResult> GetOrdersbyOrderDateFilter(DateTime date1, DateTime date2)
        {


            var order = await _ordersService.GetOrdersbyOrderDateFilter(date1,date2);


            return Ok(order);
            

        }

        [HttpGet("OrderbyRestorationDateFilter")]

        public async Task<IActionResult> GetOrdersbyRestorationDateFilter(DateTime date1, DateTime date2)
        {


            var order = await _ordersService.GetOrdersbyRestorationDateFilter(date1, date2);


            return Ok(order);

        }


        [HttpGet("OrderbyMember")]

        public async Task<IActionResult> GetOrdersByMemberId([FromQuery] int MemberId)
        {
            var member = await _memberService.GetMembersById(MemberId);

            if (member == null)
                return NotFound("Wrong Id:" + MemberId);

            var order = await _ordersService.GetOrdersByMemberId(MemberId);


            return Ok(order);

        }

        

        [HttpGet("OrderbyBook")]

        public async Task<IActionResult> GetOrdersByBookId([FromQuery] int BookId)
        {
            var book = await _booksService.GetBookById(BookId);

            if (book == null)
                return NotFound("Wrong Id:" + BookId);

            var orders = await _ordersService.GetOrdersByBookId(BookId);

            return Ok(orders);

        }


        [HttpPost]
        public async Task<IActionResult> AddOrder([FromQuery] OrderDto dto, [FromBody] List<ItemsDto> dto2)
        {

            var member = await _memberService.GetMembersById(dto.MemberId);

            if (member == null)
                return NotFound("Wrong Id: " + dto.MemberId);

            var order = await _ordersService.AddOrder(dto, dto2);
            if (!order )
                return BadRequest(" wrong! please try again");
            else
            return Ok("Added successfuly");

        }



                [HttpPut("{id}")]
                public async Task<IActionResult> UpdateMember(int id, [FromQuery] EditOrderDto dto, [FromBody] List<ItemsDto> dto2)
                {
                    var order = await _ordersService.GetOrdersByOrderId(id);

                  if (order == null)
                         return NotFound("Wrong Id:" + id);
                     var restoration = await _ordersService.IsOrderRestored(id);

                   if (!restoration )
                         return BadRequest("The order is restored !, you can't edit ");

            var member = await _memberService.GetMembersById(dto.MemberId);
            if (member == null)
                return NotFound("Wrong Id: " + dto.MemberId); 

            var updateorder = await _ordersService.UpdateOrder(id,dto, dto2);
            if (!updateorder)
                return BadRequest(" wrong! please try again");
            else
                return Ok("Added successfuly");


        }

                


        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _ordersService.GetOrdersByOrderId(id);

            if (order == null)
                return NotFound("Wrong Id:" + id);
            var restoration = await _ordersService.IsOrderRestored(id);

            if (!restoration)
                return BadRequest("The order is restored !, you can't edit ");

            var Deleteorder = await _ordersService.DeleteOrder(id);
            if (!Deleteorder)
                return BadRequest(" wrong! please try again");
            else
                return Ok("Removed successfuly");
        }

    }
}
