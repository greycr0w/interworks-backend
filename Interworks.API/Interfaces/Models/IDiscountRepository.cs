using System.Linq;
using Interworks.API.Models;
using Interworks.API.Repositories;

namespace Interworks.API.Interfaces {
    public interface IDiscountRepository : IRepositoryAsync<Discount> {

        public IQueryable<DiscountedProduct> getDiscountsForProducts(IQueryable<Product> products);
    }
}