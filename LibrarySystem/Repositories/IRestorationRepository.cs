using LibrarySystem.Dto;
using LibrarySystem.Models;

namespace LibrarySystem.Repositories
{
    public interface IRestorationRepository:IBaseRepository<Restoration>
    {
        Task<IEnumerable<RestorationOutputDto>> GetAllRestorationsAsync();
    }
}
