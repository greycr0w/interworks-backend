using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Models;
using Interworks.API.Repositories;
using Interworks.API.Services;

namespace Interworks.API.Interfaces {
    
    public interface IDiscountService {
        public IQueryable<DiscountedProduct> getDiscountsForProducts(IQueryable<Product> products);
        public DiscountAppliedProduct applyDiscount(DiscountedProduct product);

    }
}