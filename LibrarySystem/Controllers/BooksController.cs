using LibrarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Dto;
using LibrarySystem.Services;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksServices _booksService;
        private readonly ICategoriesService _categoriesService;

        public BooksController(IBooksServices booksService, ICategoriesService categoriesService)
        {
            _booksService = booksService;
            _categoriesService = categoriesService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();
            return Ok(books);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBookById(int id)
        {


            var book = await _booksService.GetBookById(id);

            if (book == null)
                return NotFound("Wrong Id: " + id);

            return Ok(book);

        }

        [HttpGet("BooksByCategory")]

        public async Task<IActionResult> GetBooksByCategory(int Categoryid)
        {
            var category = await _categoriesService.GetCategoriesById(Categoryid);

            if (category == null)
                return NotFound("Wrong Id: " + Categoryid);
            
                var books = await _booksService.GetBooksByCategory(Categoryid);
            return Ok(books);


        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] BookDto dto)
        {

            var Book = new Book{ Title = dto.Title,
                CategoryId=dto.CategoryId,
                AllQuantity = dto.AllQuantity
            
            };

           var book= await _booksService.AddBook(Book);

            return Ok(book);



        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] EditBookDto dto)
        {
            var book = await _booksService.GetBookById(id);

            if (book == null)
                return NotFound("Wrong Id: " + id);

            var category = await _categoriesService.GetCategoriesById(dto.CategoryId);

            if (category == null)
                return NotFound("Wrong Id: " + dto.CategoryId);


             book.Title=dto.Title;
            book.CategoryId=dto.CategoryId;
            book.AllQuantity=dto.AllQuantity;
            book.AvailableQuantity = dto.AvailableQuantity;


            book =  _booksService.UpdateBook(book);
            return Ok("Updated done successfully");

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksService.GetBookById(id);

            if (book == null)
                return NotFound("Wrong Id: " + id);
            
            book =   _booksService.DeleteBook(book);
            return Ok(book);
           

        }

    }
}
