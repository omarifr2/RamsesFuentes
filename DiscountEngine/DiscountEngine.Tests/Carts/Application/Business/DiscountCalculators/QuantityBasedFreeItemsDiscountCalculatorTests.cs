using DiscountEngine.Carts.Core.Models;
using DiscountEngine.Carts.Application.Business.DiscountCalculators;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class QuantityBasedFreeItemsDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [Test]
        public void QuantityBasedFreeItemsDiscountCalculatorTests_ShouldApplySingleDiscount()
        {
            Cart cart = new Cart(TestCart.Items);
            QuantityBasedFreeItemsDiscountCalculator sut = new QuantityBasedFreeItemsDiscountCalculator();
            CartDiscount discount = sut.CalculateDiscount(cart);
            
            Assert.IsNotNull(discount);
            
            cart.Discounts.Add(discount);
            Assert.Equals(cart.Subtotal, TestCartSubtotal);
        }
    }
}
