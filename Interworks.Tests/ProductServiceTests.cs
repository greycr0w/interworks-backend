using System;
using System.Collections.Generic;
using System.Linq;
using Interworks.API.Entities.Part1;
using Interworks.API.Interfaces;
using Interworks.API.Services;
using Moq;
using Xunit;

namespace Interworks.Tests {
    public class ProductServiceTests {

        private readonly IProductService _productService;
        private readonly Mock<IRepositoryAsync<Product>> _mockProductRepository;
        private readonly Mock<IDiscountRepository> _mockDiscountRepository;
        
        public ProductServiceTests() {
            _mockProductRepository = new Mock<IRepositoryAsync<Product>>();
            _mockDiscountRepository = new Mock<IDiscountRepository>();

            _productService = new ProductService(_mockProductRepository.Object, new DiscountService(_mockDiscountRepository.Object));
        }
        
        [Fact]
        public void TestNoDiscount() {
            _mockProductRepository
                .Setup(a => a.find())
                .Returns(new EnumerableQuery<Product>(new List<Product>() {
                    new Product() {
                        category = new Category() {
                            
                        },
                        createdAt = DateTimeOffset.Now,
                        name = "Σονε βανε",
                        isSubscription = true,
                        description = "Σομε Δεσψριπτιον",
                        monthsActive = 12,
                        price = 100,
                        productDiscounts = new List<ProductDiscount>() {
                            new ProductDiscount() {
                                discount = new Discount() {
                                    expiresAt = DateTimeOffset.Now.AddMinutes(-10),
                                    isFixed = false,
                                    amount = 50,
                                    thresholdAmount = 100
                                }
                            }
                        }
                    }
                }));


            var products = _productService.getProductsForClients();

            Assert.Single(products);
            Assert.Empty(products.First().AppliedDiscounts);
            Assert.Equal(100, products.First().finalPrice);
        }
        
        [Fact]
        public void TestDiscount() {
            _mockProductRepository
                .Setup(a => a.find())
                .Returns(new EnumerableQuery<Product>(new List<Product>() {
                    new Product() {
                        category = new Category() {
                            
                        },
                        createdAt = DateTimeOffset.Now,
                        name = "Σονε βανε",
                        isSubscription = true,
                        description = "Σομε Δεσψριπτιον",
                        monthsActive = 12,
                        price = 100,
                        productDiscounts = new List<ProductDiscount>() {
                            new ProductDiscount() {
                                discount = new Discount() {
                                    expiresAt = DateTimeOffset.Now.AddMinutes(10),
                                    isFixed = false,
                                    amount = 50,
                                    thresholdAmount = 100,
                                    isAutomaticallyApplied = true
                                }
                            }
                        }
                    }
                }));


            var products = _productService.getProductsForClients();

            Assert.Single(products);
            Assert.NotEmpty(products.First().AppliedDiscounts);
            Assert.Equal(50, products.First().finalPrice);
        }
    }
}