using CleanArchitecture.Domain.Entities;

using MediatR;

namespace CleanArchitecture.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public ProductRemoveCommand(int id)
        {
            id = Id;
        }

        public int Id { get; set; }
    }
}