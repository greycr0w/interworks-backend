using System.Collections.Generic;
using System.Threading.Tasks;
using Interworks.API.Models;

namespace Interworks.API.Interfaces {
    
    public interface IDiscountService {
        Task<List<Discount>> discounts(string username);
        Task<List<decimal>> applyDiscounts();

    }
}