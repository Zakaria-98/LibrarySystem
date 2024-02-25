using LibrarySystem.Models;
using LibrarySystem.Queries.CategoryQueries;
using LibrarySystem.Commands.CategoryCommands;
using LibrarySystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MediatR;


namespace LibrarySystem.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMediator _mediator;

        public CategoriesService( IUnitOfWork unitofwork, IMediator mediator)
        {
            
            _unitofwork = unitofwork;
            _mediator = mediator;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return result;

        }



        public async Task<Category> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return null;

            return result;


        }

        public async Task<Category> AddCategory(Category category)
        {
            var command = new AddCategoryCommand(category);
            var result = await _mediator.Send(command);
            return result;


        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var command = new UpdateCategoryCommand(category);
            var result = await _mediator.Send(command);
            return result;

        }

        public async Task<Category> DeleteCategory(Category category)
        {
            var command = new DeleteCategoryCommand(category);
            var result = await _mediator.Send(command);
            return result;


        }

    }
}
