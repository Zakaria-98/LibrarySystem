using LibrarySystem.Commands.RestorationCommands;
using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.Queries.RestorationQuiries;
using LibrarySystem.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Services
{
    public class RestorationService:IRestorationService
    {
        private ApplicationDbContext _context;
        private readonly IUnitOfWork _unitofwork;
        private readonly IMediator _mediator;


        public RestorationService(ApplicationDbContext context, IUnitOfWork unitofwork, IMediator mediator)
        {
            _context = context;
            _unitofwork = unitofwork;
            _mediator = mediator;
        }
        public async Task<IEnumerable<RestorationOutputDto>> GetAllRestorations()
        {
            var query = new GetAllRestorationsQuery();
            var result = await _mediator.Send(query);
            return result;

        }

        public async Task<bool> AddRestoration(int id)
        {

            var command = new AddRestorationCommand(id);
            var result = await _mediator.Send(command);


            return result;

        }


        public async Task<bool> DeleteRestoration(int id)
        {
            var command = new DeleteRestorationCommand(id);
            var result = await _mediator.Send(command);


            return result;

        }
    }
}
