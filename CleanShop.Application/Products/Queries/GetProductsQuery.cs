using CleanShop.Domain.Entities;

using MediatR;

namespace CleanShop.Application.Products.Queries;
public class GetProductsQuery : IRequest<IEnumerable<Category>> { }