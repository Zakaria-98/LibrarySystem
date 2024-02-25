using LibrarySystem.Dto;
using LibrarySystem.Models;
using MediatR;
namespace LibrarySystem.Commands.OrderCommands
{
    public class AddOrderCommand : IRequest<string>
    {
       public OrderDto OrderDto;
        public List<ItemsDto> Items;
        public AddOrderCommand(OrderDto orderDto, List<ItemsDto> items)
        {
            this.OrderDto = orderDto;
            this.Items = items;

        }
    }
}
