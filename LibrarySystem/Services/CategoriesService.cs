using LibrarySystem.Models;
using LibrarySystem.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;

        public CategoriesService(ApplicationDbContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {


            var categories = await _unitofwork.Categories.GetAllAsync();
            return categories;
        }



        public async Task<Category> GetCategoriesById(int id)
        {


            var category = await _unitofwork.Categories.GetByIdAsync(id);
            if (category == null)
                return null;

            return category;


        }

        public async Task<Category> AddCategory(Category category)
        {

            var result = await _unitofwork.Categories.AddAsync(category);
            _unitofwork.Complete();
            return result;
        }

        public  Category UpdateCategory(Category category)
        {

           _unitofwork.Categories.Update(category);
            _unitofwork.Complete();

            return category;
        }

        public  Category DeleteCategory(Category category)
        {
           _unitofwork.Categories.Delete(category);
            _unitofwork.Complete();

            return category;
        }

    }
}
