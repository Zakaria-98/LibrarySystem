using LibrarySystem.Dto;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Repositories
{
    public interface IRestorationRepository:IBaseRepository<Restoration>
    {
    Task<IEnumerable<RestorationOutputDto>> GetAllRestorationsAsync();

}
}
