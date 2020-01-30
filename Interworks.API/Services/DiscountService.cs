using Interworks.API.Interfaces;
using Interworks.API.Models;

namespace Interworks.API.Services {
    public class DiscountService  {

        private readonly IRepositoryAsync<Discount> _discountRepository;

        public DiscountService(IRepositoryAsync<Discount> userRepository) {
            this._discountRepository = userRepository;
        }


    }
}