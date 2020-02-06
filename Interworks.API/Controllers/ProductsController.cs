using System;
using System.Linq;
using Interworks.API.Entities.Part1;
using Interworks.API.Interfaces;
using Interworks.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interworks.API.Controllers {
    
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService) {
            this._productService = productService;
        }
        
        [HttpGet("productsForClients")]
        public IActionResult getAllProductsForClients() {
            var productsForClients = _productService.getProductsForClients();
            return Ok(productsForClients.AsEnumerable());
        }

        [HttpPost("purchaseProduct")]
        public IActionResult purchaseProduct([FromBody] Guid id) {
            return Ok("Purchase successful");
        }
        
        [HttpGet]
        public IActionResult getAllProducts() {
            var products = _productService.getAll();
            return Ok(products);
        }
        
    }
}