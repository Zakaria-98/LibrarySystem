using LibrarySystem.Dto;
using LibrarySystem.Models;
using MediatR;

namespace LibrarySystem.Queries.RestorationQuiries
{
    public class GetAllRestorationsQuery : IRequest<IEnumerable<RestorationOutputDto>>
    {
    }
}
