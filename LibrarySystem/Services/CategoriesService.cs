using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ApplicationDbContext _context;
        public CategoriesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _context.Categories
                .Select(g => new Category
            {
                Id = g.Id,
                Name = g.Name,
               


            }).ToListAsync();
            return  categories;
        }

        public async Task<Category> AddCategory(Category category)
        {

            _context.Categories.AddAsync(category);
            _context.SaveChanges();
            return category;
        }

        public async Task<Category> GetCategoriesById(int id)
        {

                var category = await _context.Categories
                    .Where(c => c.Id == id)
                    .Select(g => new Category
                    {
                        Name = g.Name,
                        Id = g.Id,
                // Add other properties if necessary
                    })
                    .SingleOrDefaultAsync();

                return category;
            

        }

        public async Task<Category> UpdateCategory(Category category)
        {

            _context.Update(category);
            _context.SaveChanges();

            return category;
        }

        public async Task<Category> DeleteCategory(Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();

            return category;
        }

    }
}
