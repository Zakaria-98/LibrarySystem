using LibrarySystem.Dto;
using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.OrderCommands
{
    public class AddOrderCommand : IRequest<string>
    {
        public int MemberId;

        public List<ItemsDto> Items;

    }
}
