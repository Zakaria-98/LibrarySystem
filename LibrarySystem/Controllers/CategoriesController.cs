using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Dto;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.Services;
using LibrarySystem.UnitOfWork;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

            private readonly ICategoriesService _categoriesService;

            
        public CategoriesController(ICategoriesService categoriesService)
            {
            _categoriesService = categoriesService;
            
            }

            [HttpGet]

            public async Task<IActionResult> GetAllCategories()
            {
            var categories = await _categoriesService.GetAllCategories();
                return Ok(categories);

            }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategoriesById(int id)
        {

            var category = await _categoriesService.GetCategoryById(id);

            if (category == null)
                return BadRequest("Wrong Id !");

            return Ok(category);

        }


            [HttpPost]
            public async Task<IActionResult> AddCategory([FromBody] CategoryDto dto)
            {

            
              var category = new Category { Name = dto.Name };

               await _categoriesService.AddCategory(category);

            return Ok(category);

            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto dto)
            {



            var category = await _categoriesService.GetCategoryById(id);

            if (category == null)
                return NotFound("Wrong Id !");

            category.Name = dto.Name;
           var Category= _categoriesService.UpdateCategory(category);    
           
            return Ok("Updated done successfully");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var category = await _categoriesService.GetCategoryById(id);

            if (category == null)
                return NotFound("Wrong Id !");


            _categoriesService.DeleteCategory(category);

            return Ok("Updated done successfully");

        }


    }
    }
