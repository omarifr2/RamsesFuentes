using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class CategoryDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [Test]
        public void CuponCodeDiscountCalculatorcsTestsTests_ShouldApplySingleDiscount()
        {
            Cart cart = new Cart(TestCart.Items);
            CategoryDiscountCalculator sut = new CategoryDiscountCalculator();
            CartDiscount discount = sut.CalculateDiscount(cart);

            Assert.IsNotNull(discount);

            cart.Discounts.Add(discount);
            Assert.Equals(cart.Subtotal, TestCartSubtotal);
        }
    }
}
