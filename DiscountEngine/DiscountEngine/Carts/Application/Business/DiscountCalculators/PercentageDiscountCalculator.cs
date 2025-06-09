using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Carts.Application.Business.DiscountCalculators
{
    public class PercentageDiscountCalculator(decimal percentage) : IDiscountCalculator
    {
        public CartDiscount? CalculateDiscount(Cart cart)
        {
            string description = $"{percentage}% off on all products";
            return new CartDiscount(description, cart.Subtotal * (percentage / 100m));
        }
    }
}
