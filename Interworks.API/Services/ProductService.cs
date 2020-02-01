using System.Collections.Generic;
using System.Linq;
using Interworks.API.Interfaces;
using Interworks.API.Models;
using Interworks.API.Repositories;

namespace Interworks.API.Services {
    public class ProductService : IProductService {
        //call discount service to get discount products(automatic ones)

        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly DiscountService _discountService;

        public ProductService(ProductRepository productRepository, DiscountService discountService) {
            this._productRepository = productRepository;
            this._discountService = discountService;
        }

        public List<DiscountAppliedProduct> getProducts() {
            var allProducts = getAll();
            return _discountService.getListingsWithDiscountApplied(allProducts);
        }

        public IQueryable<Product> getAll() {
            return _productRepository.find();
            
        }
    }
}