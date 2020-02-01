using Interworks.API.Models;
using Interworks.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Interworks.API.Controllers {
    
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase {

        private readonly ProductService _productService;

        public ProductsController(ProductService productService) {
            this._productService = productService;
        }
        
        [HttpGet]
        public IActionResult GetAll() {
            var products = _productService.getAll();
            return Ok(products);
        }
    }
}