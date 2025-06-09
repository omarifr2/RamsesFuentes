using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class PercentageDiscountCalculatorTests : BaseDiscountCalculatorTests
    {

        [TestCase(10, "10% off on all products", 210.211)]
        [TestCase(20, "20% off on all products", 420.422)]
        [TestCase(15, "15% off on all products", 315.3165)]
        [TestCase(5, "5% off on all products", 105.1055)]
        public void PercentageDiscountCalculator_ShouldApplySingleDiscount(decimal percentaje, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            PercentageDiscountCalculator sut = new PercentageDiscountCalculator(percentaje);

            // Act
            CartDiscount discount = sut.CalculateDiscount(cart);
            cart.Discounts.Add(discount);

            // Assert
            Assert.IsNotNull(discount);
            Assert.That(discount.Description, Is.EqualTo(expectedDescription));
            Assert.That(discount.Amount, Is.EqualTo(expectedAmount));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(cart.Total, Is.EqualTo(TestCartSubtotal - expectedAmount));
        }
    }
}
