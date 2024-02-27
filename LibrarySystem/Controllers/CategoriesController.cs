using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Dto;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using MediatR;
using LibrarySystem.Queries.CategoryQueries;
using LibrarySystem.Commands.CategoryCommands;


namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly IMediator _mediator;



        public CategoriesController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]

            public async Task<IActionResult> GetAllCategories()
            {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);



            }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategoriesById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound("Wrong Id !");

            return Ok(result);


        }


            [HttpPost]
            public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand addCategoryCommand)
            {

            var command = addCategoryCommand;
            var result = await _mediator.Send(command);
            return Ok(result);

            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
            {
            var query = new GetCategoryByIdQuery(id);
            var categoryresult = await _mediator.Send(query);
            if (categoryresult == null)
                return NotFound("Wrong Id !");

            var category = updateCategoryCommand;
            var command = new UpdateCategoryCommand();
            var result = await _mediator.Send(command);
            
            return Ok("Updated done successfully");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(query);
            if (category == null)
                return NotFound("Wrong Id !");

            var command = new DeleteCategoryCommand(id);
            var result = await _mediator.Send(command);
            
            return Ok("Deleted done successfully");

        }


    }
    }
