using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Services
{
    public interface IBooksServices
    {
        Task<IEnumerable<Book>> GetAllBooks();

        Task<Book> GetBookById(int id);

        Task<IEnumerable<Book>> GetBooksByCategory(int Categoryid);

        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook( Book book);


        Task<Book> DeleteBook(Book book);







    }
}
