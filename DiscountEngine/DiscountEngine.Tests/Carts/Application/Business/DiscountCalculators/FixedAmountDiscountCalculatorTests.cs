using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;
namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class FixedAmountDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [Test]
        public void FixedAmountDiscountCalculatorTests_ShouldApplySingleDiscount()
        {
            Cart cart = new Cart(TestCart.Items);
            FixedAmountDiscountCalculator sut = new FixedAmountDiscountCalculator();
            CartDiscount discount = sut.CalculateDiscount(cart);

            Assert.IsNotNull(discount);

            cart.Discounts.Add(discount);
            Assert.Equals(cart.Subtotal, TestCartSubtotal);
        }
    }
}
