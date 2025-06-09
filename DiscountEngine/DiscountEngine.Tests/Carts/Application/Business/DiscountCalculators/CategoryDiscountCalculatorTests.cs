using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class CategoryDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [TestCase(Category.Electronics, 10, "10% off all products in \"Electronics\" category", 194.998)]
        [TestCase(Category.Baby, 20, "20% off all products in \"Baby\" category", 10.69)]
        [TestCase(Category.Groceries, 15, "15% off all products in \"Groceries\" category", 4.722)]
        [TestCase(Category.Meats, 10, "10% off all products in \"Meats\" category", 6.72)]
        public void CategoryDiscountCalculator_ShouldApplySingleDiscount(Category category, decimal percentaje, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            var cart = new Cart(TestCart.Items);
            var sut = new CategoryDiscountCalculator(category, percentaje);

            // Act
            var discount = sut.CalculateDiscount(cart);
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
