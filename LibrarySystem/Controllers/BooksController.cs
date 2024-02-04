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
            var books = _booksService.GetAllBooks();
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

            var category = await _categoriesService.GetCategoriesById(dto.CategoryId);

            if (category == null)
                return NotFound("Wrong Id: " + dto.CategoryId);

            var book = await _booksService.AddBook(dto);

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


           
            book = await _booksService.UpdateBook(id, dto);
            return Ok("Updated done successfully");

        }


        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _booksService.GetBookById(id);

            if (book == null)
                return NotFound("Wrong Id: " + id);
            
            book = await _booksService.DeleteBook(id);
            return Ok(book);
           

        }

    }
}
