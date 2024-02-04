using LibrarySystem.Dto;

namespace LibrarySystem.Services
{
    public interface IRestorationService
    {
        Task<IEnumerable<RestorationOutputDto>> GetAllRestorations();
        Task<bool> AddRestoration(int id);

        Task<bool> DeleteRestoration(int id);
    }
}
