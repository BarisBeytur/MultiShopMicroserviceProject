using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler
    {

        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _repository = addressRepository;
        }


        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);

            if (value == null)
            {
                throw new ApplicationException("Address not found.");
            }

            await _repository.DeleteAsync(value);
        }
    }
}
