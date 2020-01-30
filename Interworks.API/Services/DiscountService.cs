using Interworks.API.Interfaces;

namespace Interworks.API.Services {
    public class DiscountService : IDiscountService {

        private readonly IDiscountRepository _discountRepository;

        public DiscountService(IDiscountRepository _discountRepository) {
            this._discountRepository = _discountRepository;
        }


    }
}