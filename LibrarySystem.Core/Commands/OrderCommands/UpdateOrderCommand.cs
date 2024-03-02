using LibrarySystem.Dto;
using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.OrderCommands
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public int Id;
        public List<ItemsDto> Items;
        public EditOrderDto EditOrderDto;
        public UpdateOrderCommand(int id,EditOrderDto editOrderDto, List<ItemsDto> items)
        {
            this.Id = id;
            this.EditOrderDto=editOrderDto;
            this.Items = items;

        }
    }
}
