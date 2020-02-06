using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Entities;
using Interworks.API.Entities.Part1;
using Interworks.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Repositories {
    public class DiscountedProduct {
        
        public Product product { get; set; }
        
        public List<Discount> discounts { get; set; }
        
    }
    
    public class DiscountRepository :  BaseRepository<Discount>, IDiscountRepository {
        public DiscountRepository(ApplicationDbContext db) : base(db) {
            
        }

        public IQueryable<DiscountedProduct> getDiscountsOfProducts(IQueryable<Product> products) {
            var now = DateTimeOffset.UtcNow;
            var result = products
                .Select(a => new DiscountedProduct() {
                    product = a,
                    discounts = a.productDiscounts
                        .Select(b => b.discount)
                        .Where(b => b.isAutomaticallyApplied)
                        .Where(b => b.expiresAt < now)
                        .OrderBy(b => b.priority)
                        .ToList()
                });
            
            return result;
        }
    }
}