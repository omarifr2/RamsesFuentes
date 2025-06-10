using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class CouponCodeDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [TestCase(CouponCode.WELCOME10, "Coupon code: WELCOME10 - 10% off on all products", 210.211)]
        [TestCase(CouponCode.CYBERMONDAY15, "Coupon code: CYBERMONDAY15 - 15% off all products in \"Electronics\" category", 292.497)]
        public void PercentageDiscountCalculator_ShouldApplySingleDiscount(CouponCode couponCode, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            CouponCodeDiscountCalculator sut = new CouponCodeDiscountCalculator(couponCode);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);
            if (discount != null) cart.Discounts.Add(discount);

            // Assert
            Assert.IsNotNull(discount);
            Assert.That(discount.Description, Is.EqualTo(expectedDescription));
            Assert.That(discount.Amount, Is.EqualTo(expectedAmount));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(cart.Total, Is.EqualTo(TestCartSubtotal - expectedAmount));
        }
    }
}
