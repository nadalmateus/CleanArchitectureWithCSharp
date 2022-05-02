using CleanArchitecture.Domain.Entities;

using MediatR;

namespace CleanArchitecture.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public GetProductByIdQuery(int id)
        {
            Id = Id;
        }

        public int Id { get; set; }
    }
}