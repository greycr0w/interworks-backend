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
    
    public class DiscountRepository : BaseRepository<Discount>  {
        public DiscountRepository(ApplicationDbContext db) : base(db, db.discounts) {
            
        }

        public IQueryable<DiscountedProduct> getDiscountsOfProducts(IQueryable<Product> products) {
            var result = products
                .Select(a => new DiscountedProduct() {
                    product = a,
                    discounts = a.productDiscounts
                        .Select(b => b.discount)
                        .Where(b => b.isAutomaticallyApplied)
                        .Where(b => b.expiresAt < DateTimeOffset.UtcNow)
                        .OrderBy(b => b.priority)
                        .ToList()
                });
            
            return result;

            /*
            var discounts = await db.discounts
                .Where(a => a.isAutomaticallyApplied)
                .Where(a => a.expiresAt < DateTimeOffset.UtcNow)
                .Where(a => a.productDiscounts.Any(b => productIds.Contains(b.productId)))
                .OrderBy(a => a.priority)
                .Include(a => a.productDiscounts)
                .ToListAsync();

            return product
                .Select(a => new DiscountedProduct() {
                    product = a,
                    discounts = discounts
                        .Where(b => b.productDiscounts.Any(c => c.productId == a.id))
                        .ToList()
                })
                .ToList();*/
        }
    }
}