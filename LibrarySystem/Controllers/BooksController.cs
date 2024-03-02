using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using LibrarySystem.Queries.BookQueries;
using LibrarySystem.Commands.BookCommands;
using LibrarySystem.Queries.CategoryQueries;
using LibrarySystem.Commands.CategoryCommands;



namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
       
        private readonly IMediator _mediator;


        public BooksController( IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBookById(int id)
        {
            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound("Wrong Id: " + id);

            return Ok(result);


        }

        [HttpGet("BooksByCategory")]

        public async Task<IActionResult> GetBooksByCategory(int Categoryid)
        {

            var query = new GetBooksByCategoryQuery(Categoryid);
            var result = await _mediator.Send(query);
            if(result == null)
                return NotFound("Wrong Id !");

            return Ok(result);


        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand addBookCommand)
        {

            var command = addBookCommand;
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook( [FromBody] UpdateBookCommand updateBookCommand)
        {
            var command = updateBookCommand;
            var result = await _mediator.Send(command);
            if(result==null)
                return NotFound("Wrong Id: " );
            return Ok("Updated done successfully");

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {

            var command = new DeleteBookCommand(id);
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound("Wrong Id: " + id);


            return Ok("Deleted done successfully");



        }

    }
}
