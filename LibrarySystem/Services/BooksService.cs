using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class BooksService : IBooksServices
    {
        private ApplicationDbContext _context;
        public BooksService(ApplicationDbContext context)
        {
            _context = context;
        } 

        public async Task<Book> AddBook([FromBody] BookDto dto)
        {

            var book = new Book
            {
                Title = dto.Title,
                AllQuantity = dto.AllQuantity,
                AvailableQuantity = dto.AllQuantity,
                CategoryId = dto.CategoryId

            };
            _context.Books.AddAsync(book);
            _context.SaveChanges();
            return book;


        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _context.Books
                .Select(g => new Book
                {
                    Id = g.Id,
                    Title = g.Title,
                    AllQuantity = g.AllQuantity,
                    AvailableQuantity = g.AvailableQuantity,
                    CategoryId = g.CategoryId,
                })
                .ToListAsync();


            return books;
        }
        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.Where(book => book.Id == id).Select(g => new Book
            {
                Id = g.Id,
                Title = g.Title,
                CategoryId = g.CategoryId,
                AllQuantity = g.AllQuantity,
                AvailableQuantity = g.AvailableQuantity


            })
                
            .SingleOrDefaultAsync();

            return book;

        }

         public async Task<IEnumerable<Book>> GetBooksByCategory(int Categoryid)
        {  

            var books = await _context.Books.Where(c => c.CategoryId == Categoryid)
                 .Select(g => new Book
                 {
                     Id = g.Id,
                     Title = g.Title,
                     CategoryId = g.CategoryId,
                     AllQuantity = g.AllQuantity,
                     AvailableQuantity = g.AvailableQuantity


                 }).ToListAsync();
            return books;

        }



        public async Task<Book> UpdateBook(int id, [FromBody] EditBookDto dto)
        {
            var book = await GetBookById(id);

            book.Title = dto.Title;
            book.AllQuantity = dto.AllQuantity;
            book.AvailableQuantity = dto.AvailableQuantity;
            book.CategoryId = dto.CategoryId;


            _context.Update(book);
            _context.SaveChanges();
            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book = await GetBookById(id);
            _context.Remove(book);
            _context.SaveChanges();
            return book;
        }


    }
}
