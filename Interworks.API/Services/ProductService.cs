using System.Collections.Generic;
using System.Linq;
using Interworks.API.Entities.Part1;
using Interworks.API.Interfaces;
using Interworks.API.Repositories;

namespace Interworks.API.Services {
    public class ProductService : IProductService {
        //call discount service to get discount products(automatic ones)

        private readonly IRepositoryAsync<Product> _productRepository;
        private readonly IDiscountService _discountService;

        public ProductService(IRepositoryAsync<Product> productRepository, IDiscountService discountService) {
            this._productRepository = productRepository;
            this._discountService = discountService;
        }

        public List<DiscountAppliedProduct> getProductsForClients() {
            var allProducts = getAll();
            return _discountService.getListingsWithDiscountApplied(allProducts);
        }

        public IQueryable<Product> getAll() {
            return _productRepository.find();
            
        }
    }
}