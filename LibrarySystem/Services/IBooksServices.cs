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

        Task<Book> AddBook([FromBody] BookDto dto);
        Task<Book> UpdateBook(int id, [FromBody] EditBookDto dto);


        Task<Book> DeleteBook(int id);







    }
}
