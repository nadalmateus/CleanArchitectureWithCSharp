using CleanShop.Domain.Entities;

using MediatR;

namespace CleanShop.Application.Products.Queries;
public class GetProductByIdQuery : IRequest<Product>
{
    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
