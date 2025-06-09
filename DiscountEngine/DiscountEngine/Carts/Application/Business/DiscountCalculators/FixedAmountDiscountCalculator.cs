using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Carts.Application.Business.DiscountCalculators
{
    public class FixedAmountDiscountCalculator(decimal amount, decimal minimumSubtotal) : IDiscountCalculator
    {
        public CartDiscount? CalculateDiscount(Cart cart)
        {
            string description = $"${amount} off total cart value";
            if (minimumSubtotal == 0m) return new CartDiscount(description, cart.Subtotal - amount);
            if (cart.Subtotal < minimumSubtotal) return null;
            description = $"{description} if subtotal exceeds ${minimumSubtotal}";
            return new CartDiscount(description, cart.Subtotal - amount);
        }
    }
}
