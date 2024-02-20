using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class BooksService : IBooksServices
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        public BooksService(ApplicationDbContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;
        }

        public async Task<Book> AddBook( Book book)
        {

            var Book = await _unitofwork.Books.AddAsync(book);
            _unitofwork.Complete();
            return Book;


        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var Books = await _unitofwork.Books.GetAllAsync();
            return Books;
        }
        public async Task<Book> GetBookById(int id)
        {


            var Book = await _unitofwork.Books.GetByIdAsync(id);
            if (Book == null)
                return null;

            return Book;

        }

         public async Task<IEnumerable<Book>> GetBooksByCategory(int Categoryid)
        {
            var books = await _unitofwork.Books.GetListAsync(c => c.CategoryId == Categoryid,
                g => new Book
                {
                    Id = g.Id,
                    Title = g.Title,
                    CategoryId = g.CategoryId,
                    AllQuantity = g.AllQuantity,
                    AvailableQuantity = g.AvailableQuantity


                });

            return books;

        }



        public  Book UpdateBook(Book book)
        {

            _unitofwork.Books.Update(book);
            _unitofwork.Complete();

            return book;
        }

        public Book DeleteBook(Book book)
        {
            _unitofwork.Books.Delete(book);
            _unitofwork.Complete();

            return book;
        }


    }
}
