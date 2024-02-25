using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.RestorationQuiries;
using LibrarySystem.UnitOfWork;
using MediatR;

namespace LibrarySystem.Handlers.Queries.RestorationQuiries
{
    public class GetAllRestorationsHandler : IRequestHandler<GetAllRestorationsQuery, IEnumerable<RestorationOutputDto>>
    {
        private readonly IUnitOfWork _unitofwork;

        public GetAllRestorationsHandler(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public async Task<IEnumerable<RestorationOutputDto>> Handle(GetAllRestorationsQuery request, CancellationToken cancellationToken)
        {
            var restorations = await _unitofwork.Restorations.GetAllAsync((o => new RestorationOutputDto
            {
                Id = o.Id,
                RestorationDate = o.RestorationDate,
                OrderId = o.Order.Id

            }));

            return restorations;
        }
    }
}
