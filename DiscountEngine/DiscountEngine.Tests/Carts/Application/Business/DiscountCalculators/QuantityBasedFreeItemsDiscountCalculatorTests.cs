using DiscountEngine.Carts.Core.Models;
using DiscountEngine.Carts.Application.Business.DiscountCalculators;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class QuantityBasedFreeItemsDiscountCalculatorTests : BaseDiscountCalculatorTests
    {
        [TestCase("Chicken Breast", 3, 2, "Buy 3 get 2 free on \"Chicken Breast\"", 15.78)]
        [TestCase("Whole Wheat Pasta", 5, 1, "Buy 5 get 1 free on \"Whole Wheat Pasta\"", 2.39)]
        public void QuantityBasedFreeItemsDiscountCalculatorTests_ShouldApplySingleDiscount(string productName, int requiredQuantity, int discountQuantity, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            Product? product = TestCart.Items.First(item => item.Product.Name == productName).Product;
            QuantityBasedFreeItemsDiscountCalculator sut = new QuantityBasedFreeItemsDiscountCalculator(product, requiredQuantity, discountQuantity);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);
            if (discount != null) cart.Discounts.Add(discount);

            // Assert
            Assert.IsNotNull(discount);
            Assert.That(discount.Description, Is.EqualTo(expectedDescription));
            Assert.That(discount.Amount, Is.EqualTo(expectedAmount));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(cart.FinalTotal, Is.EqualTo(TestCartSubtotal - expectedAmount));
        }

        [TestCase("Whole Milk", 3, 2, "Buy 3 get 2 free on \"Whole Milk\", only 1 items discounted", 1.79)]
        [TestCase("Diapers Size M", 2, 2, "Buy 2 get 2 free on \"Diapers Size M\", only 1 items discounted", 15.49)]
        public void QuantityBasedFreeItemsDiscountCalculatorTests_PartialDiscountApplied(string productName, int requiredQuantity, int discountQuantity, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            Product? product = TestCart.Items.First(item => item.Product.Name == productName).Product;
            QuantityBasedFreeItemsDiscountCalculator sut = new QuantityBasedFreeItemsDiscountCalculator(product, requiredQuantity, discountQuantity);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);
            if (discount != null) cart.Discounts.Add(discount);

            // Assert
            Assert.IsNotNull(discount);
            Assert.That(discount.Description, Is.EqualTo(expectedDescription));
            Assert.That(discount.Amount, Is.EqualTo(expectedAmount));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(cart.FinalTotal, Is.EqualTo(TestCartSubtotal - expectedAmount));
        }

        [TestCase("Smartphone", 1, 1, "Buy 1 get 1 free on \"Smartphone\", no item to discount", 0)]
        [TestCase("Baby Wipes", 2, 1, "Buy 2 get 1 free on \"Baby Wipes\", no item to discount", 0)]
        public void QuantityBasedFreeItemsDiscountCalculatorTests_DiscountAppliedButNoItemsToDiscount(string productName, int requiredQuantity, int discountQuantity, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            Product? product = TestCart.Items.First(item => item.Product.Name == productName).Product;
            QuantityBasedFreeItemsDiscountCalculator sut = new QuantityBasedFreeItemsDiscountCalculator(product, requiredQuantity, discountQuantity);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);
            if (discount != null) cart.Discounts.Add(discount);

            // Assert
            Assert.IsNotNull(discount);
            Assert.That(discount.Description, Is.EqualTo(expectedDescription));
            Assert.That(discount.Amount, Is.EqualTo(expectedAmount));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(cart.FinalTotal, Is.EqualTo(TestCartSubtotal - expectedAmount));
        }

        [TestCase("Ground Beef", 8, 1, "", 0)]
        public void QuantityBasedFreeItemsDiscountCalculatorTests_NotEnoughArticlesToApplyDiscount(string productName, int requiredQuantity, int discountQuantity, string expectedDescription, decimal expectedAmount)
        {
            // Arrange
            Cart cart = new Cart(TestCart.Items);
            Product? product = TestCart.Items.First(item => item.Product.Name == productName).Product;
            QuantityBasedFreeItemsDiscountCalculator sut = new QuantityBasedFreeItemsDiscountCalculator(product, requiredQuantity, discountQuantity);

            // Act
            CartDiscount? discount = sut.CalculateDiscount(cart);

            // Assert
            Assert.IsNull(discount);
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.Subtotal));
            Assert.That(TestCartSubtotal, Is.EqualTo(cart.FinalTotal));
        }
    }
}
