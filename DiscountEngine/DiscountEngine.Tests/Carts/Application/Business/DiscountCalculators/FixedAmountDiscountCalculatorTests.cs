using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class FixedAmountDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [TestCase(10, 0, "$10 off total cart value", 10, 2092.11)]
        [TestCase(50, 200, "$10 off total cart value if subtotal exceeds $200", 10, 2052.11)]
        public void FixedAmountDiscountCalculatorTests_ShouldApplySingleDiscount(decimal amount, decimal minimumSubtotal, string expectedDescription, decimal expectedAmount, decimal expectedFinalTotal)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            FixedAmountDiscountCalculator sut = new FixedAmountDiscountCalculator(amount, minimumSubtotal);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);
            if (discount != null) cart.Discounts.Add(discount);

            // Assert
            Assert.IsNotNull(discount);
            Assert.That(discount.Description, Is.EqualTo(expectedDescription));
            Assert.That(discount.Amount, Is.EqualTo(expectedAmount));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(expectedFinalTotal, Is.EqualTo(cart.FinalTotal));
        }

        [TestCase(200, 2500, "$500 off on all products if subtotal exceeds $2500", 2102.11)]
        public void FixedAmountDiscountCalculatorTests_ShouldNotApplySingleDiscount(decimal amount, decimal minimumSubtotal, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            FixedAmountDiscountCalculator sut = new FixedAmountDiscountCalculator(amount, minimumSubtotal);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);

            // Assert
            Assert.IsNull(discount);
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.FinalTotal));
        }
    }
}
