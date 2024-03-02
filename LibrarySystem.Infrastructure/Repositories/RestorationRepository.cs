using LibrarySystem.Dto;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repositories
{
    public class RestorationRepository:BaseRepository<Restoration>,IRestorationRepository
    {
        private ApplicationDbContext _context;

        public RestorationRepository(ApplicationDbContext  context) :base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RestorationOutputDto>> GetAllRestorationsAsync() 
        {
            var result = await _context.Restorations.Select((o => new RestorationOutputDto
            {
                Id = o.Id,
                RestorationDate = o.RestorationDate,
                OrderId = o.Order.Id

            })).ToListAsync();
            if (result == null)
                return null;

            return result;
        }
    }
}
