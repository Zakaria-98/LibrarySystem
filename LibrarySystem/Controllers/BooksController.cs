﻿using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Dto;
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
            var categoryquery = new GetCategoryByIdQuery(Categoryid);
            var categoryresult = await _mediator.Send(categoryquery);
            if (categoryresult == null)
                return NotFound("Wrong Id !");


            var query = new GetBooksByCategoryQuery(Categoryid);
            var result = await _mediator.Send(query);


            return Ok(result);




        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto dto)
        {

            var Book = new Book{ Title = dto.Title,
                CategoryId=dto.CategoryId,
                AllQuantity = dto.AllQuantity
            
            };

            var command = new AddBookCommand(Book);
            var result = await _mediator.Send(command);


            return Ok(result);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] EditBookDto dto)
        {
            var categoryquery = new GetCategoryByIdQuery(dto.CategoryId);
            var categoryresult = await _mediator.Send(categoryquery);
            if (categoryresult == null)
                return NotFound("Wrong Id !");

            var bookquery = new GetBookByIdQuery(id);
            var book = await _mediator.Send(bookquery);
            if (book == null)
                return NotFound("Wrong Id: " + id);

            book.Title = dto.Title;
            book.CategoryId = dto.CategoryId;
            book.AllQuantity = dto.AllQuantity;
            book.AvailableQuantity = dto.AvailableQuantity;


            var command = new UpdateBookCommand(book);
            var result = await _mediator.Send(command);


            return Ok("Updated done successfully");



        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var bookquery = new GetBookByIdQuery(id);
            var book = await _mediator.Send(bookquery);
            if (book == null)
                return NotFound("Wrong Id: " + id);

            var command = new DeleteBookCommand(book);
            var result = await _mediator.Send(command);


            return Ok("Deleted done successfully");



        }

    }
}
