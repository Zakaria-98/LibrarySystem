using LibrarySystem.Commands.BookCommands;
using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.BookQueries;
using LibrarySystem.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class BooksService : IBooksServices
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;
        private readonly IMediator _mediator;

        public BooksService(ApplicationDbContext context, IUnitOfWork unitofwork, IMediator mediator)
        {
            _context = context;
            _unitofwork = unitofwork;
            _mediator = mediator;
        }



        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return result;
        }
        public async Task<Book> GetBookById(int id)
        {

            var query = new GetBookByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return null;

            return result;



        }

         public async Task<IEnumerable<Book>> GetBooksByCategory(int Categoryid)
        {
            var query = new GetBooksByCategoryQuery(Categoryid);
            var result = await _mediator.Send(query);


            return result;



        }

        public async Task<Book> AddBook(Book book)
        {
            var command = new AddBookCommand(book);
            var result = await _mediator.Send(command);


            return result;


        }


        public async Task<Book> UpdateBook(Book book)
        {
            var command = new UpdateBookCommand(book);
            var result = await _mediator.Send(command);


            return result;

        }

        public async Task<Book> DeleteBook(Book book)
        {
            var command = new DeleteBookCommand(book);
            var result = await _mediator.Send(command);


            return result;

        }


    }
}
