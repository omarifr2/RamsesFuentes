using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class PercentageDiscountCalculatorTests : BaseDiscountCalculatorTests
    {

        [Test]
        public void PercentageDiscountCalculatorTestsTests_ShouldApplySingleDiscount()
        {
            Cart cart = new Cart(TestCart.Items);
            PercentageDiscountCalculator sut = new PercentageDiscountCalculator();
            CartDiscount discount = sut.CalculateDiscount(cart);

            Assert.IsNotNull(discount);

            cart.Discounts.Add(discount);
            Assert.Equals(cart.Subtotal, TestCartSubtotal);
        }
    }
}
