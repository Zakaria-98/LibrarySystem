using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoriesById(int id);

        Task<Category> AddCategory(Category category);

        Category UpdateCategory(Category category);

        Category DeleteCategory(Category category);
        
    }
}
