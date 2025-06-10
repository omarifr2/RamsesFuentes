using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Carts.Core.Interfaces.Business
{
    public abstract class DiscountCalculatorDecorator(IDiscountCalculator discountCalculator) : IDiscountCalculator
    {
        protected IDiscountCalculator discountCalculator = discountCalculator;
        public abstract CartDiscount? CalculateDiscount(Cart cart);
    }
}
