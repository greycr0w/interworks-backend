using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Entities.Part1;
using Interworks.API.Repositories;
using Interworks.API.Services;

namespace Interworks.API.Interfaces {
    
    public interface IDiscountService {
        public IQueryable<DiscountedProduct> getDiscountsForProducts(IQueryable<Product> products);
        public DiscountAppliedProduct applyDiscount(DiscountedProduct product);
        
        List<DiscountAppliedProduct> getListingsWithDiscountApplied(IQueryable<Product> allProducts);

    }
}