using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interworks.API.Models;
using Interworks.API.Services;

namespace Interworks.API.Interfaces {
    public interface IProductService {

        List<DiscountAppliedProduct> getProducts();
        IQueryable<Product> getAll();
    }
}