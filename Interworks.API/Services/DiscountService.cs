using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interworks.API.Interfaces;
using Interworks.API.Models;
using Interworks.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Interworks.API.Services {
    public class DiscountAppliedProduct {
        public Product Product { get; set; }
        
        public List<AppliedDiscount> AppliedDiscounts { get; set; }
        
        public decimal finalPrice { get; set; }
    }

    public class AppliedDiscount {
        public Discount appliedDiscount { get; set; }
        
        public decimal priceBefore { get; set; }
        
        public decimal priceAfter { get; set; }
    }
    
    public class DiscountService : IDiscountService {

        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository discountRepository) {
            this._discountRepository = discountRepository;
        }
        
        
        public IQueryable<DiscountedProduct> getDiscountsForProducts(IQueryable<Product> products) {
            var discountedProducts = _discountRepository.getDiscountsForProducts(products);
            return discountedProducts;
        }

        public DiscountAppliedProduct applyDiscount(DiscountedProduct product) {
            decimal price = product.product.price;
            List<AppliedDiscount> appliedDiscounts = new List<AppliedDiscount>();

            foreach (var discount in product.discounts) {
                decimal priceBefore = price;

                if (discount.isFixed) {
                    price -= discount.amount;
                }
                else {
                    price -= price * (discount.amount / 100);
                }

                appliedDiscounts.Add(new AppliedDiscount() {
                    priceBefore = priceBefore,
                    priceAfter = price,
                    appliedDiscount = discount
                });
            }

            return new DiscountAppliedProduct() {
                AppliedDiscounts = appliedDiscounts,
                finalPrice = price,
                Product = product.product
            };
        }

        public List<DiscountAppliedProduct> getListingsWithDiscountApplied(IQueryable<Product> allProducts) {
            
            var productDiscounts = getDiscountsForProducts(allProducts)
                .ToList()
                .Select(applyDiscount)
                .ToList();
            
            return productDiscounts;
        }
    }
}