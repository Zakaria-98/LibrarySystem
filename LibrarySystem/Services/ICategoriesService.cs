using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoriesById(int id);

        Task<Category> AddCategory(Category category);

        Task<Category> UpdateCategory(Category category);

        Task<Category> DeleteCategory(Category category);
        
    }
}
