using System.Collections.Generic;
using System.Linq;
using Interworks.API.Entities.Part1;
using Interworks.API.Repositories;
using Interworks.API.Services;

namespace Interworks.API.Interfaces {
    public interface IDiscountRepository : IRepositoryAsync<Discount> {
        IQueryable<DiscountedProduct> getDiscountsOfProducts(IQueryable<Product> products);
    }
}