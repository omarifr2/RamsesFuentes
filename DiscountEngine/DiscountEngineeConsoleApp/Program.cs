// See https://aka.ms/new-console-template for more information

// Electronics
using DiscountEngine.Carts.Application.Business.DiscountCalculators;
using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;

Product smartphone = new Product { Id = 1, Sku = "ELEC001", Name = "Smartphone", Category = Category.Electronics, Price = 699.99m };
Product bluetoothHeadphones = new Product { Id = 5, Sku = "ELEC002", Name = "Bluetooth Headphones", Category = Category.Electronics, Price = 49.99m };
Product laptop = new Product { Id = 9, Sku = "ELEC003", Name = "Laptop", Category = Category.Electronics, Price = 1200.00m };

// Baby
Product diapersSizeM = new Product { Id = 2, Sku = "BABY001", Name = "Diapers Size M", Category = Category.Baby, Price = 15.49m };
Product babyWipes = new Product { Id = 7, Sku = "BABY002", Name = "Baby Wipes", Category = Category.Baby, Price = 3.49m };

// Groceries
Product oatmealCereal = new Product { Id = 3, Sku = "GROC001", Name = "Oatmeal Cereal", Category = Category.Groceries, Price = 4.99m };
Product wholeMilk = new Product { Id = 6, Sku = "GROC002", Name = "Whole Milk", Category = Category.Groceries, Price = 1.79m };
Product wholeWheatPasta = new Product { Id = 10, Sku = "GROC003", Name = "Whole Wheat Pasta", Category = Category.Groceries, Price = 2.39m };

// Meats
Product chickenBreast = new Product { Id = 4, Sku = "MEAT001", Name = "Chicken Breast", Category = Category.Meats, Price = 7.89m };
Product groundBeef = new Product { Id = 8, Sku = "MEAT002", Name = "Ground Beef", Category = Category.Meats, Price = 9.25m };

var cartItems = new List<CartItem>
{
    new CartItem { Id = 1, Product = smartphone, Quantity = 1 },
    new CartItem { Id = 2, Product = diapersSizeM, Quantity = 3 },
    new CartItem { Id = 3, Product = oatmealCereal, Quantity = 2 },
    new CartItem { Id = 4, Product = chickenBreast, Quantity = 5 },
    new CartItem { Id = 5, Product = bluetoothHeadphones, Quantity = 1 },
    new CartItem { Id = 6, Product = wholeMilk, Quantity = 4 },
    new CartItem { Id = 7, Product = babyWipes, Quantity = 2 },
    new CartItem { Id = 8, Product = groundBeef, Quantity = 3 },
    new CartItem { Id = 9, Product = laptop, Quantity = 1 },
    new CartItem { Id = 10, Product = wholeWheatPasta, Quantity = 6 }
};

Cart cart = new Cart(cartItems);

FixedAmountDiscountCalculator fixedAmountDiscountCalculator = new FixedAmountDiscountCalculator(100, 1000);
PercentageDiscountCalculator percentageDiscountCalculator = new PercentageDiscountCalculator(5);
CouponCodeDiscountCalculator couponCodeDiscountCalculator = new CouponCodeDiscountCalculator(CouponCode.CYBERMONDAY15);
QuantityBasedFreeItemsDiscountCalculator quantityBasedFreeItemsDiscountCalculator = new QuantityBasedFreeItemsDiscountCalculator(wholeMilk, 2, 1);
CategoryDiscountCalculator categoryDiscountCalculator = new CategoryDiscountCalculator(Category.Baby, 10);

List<IDiscountCalculator> discountCalculators =
[
    fixedAmountDiscountCalculator,
    percentageDiscountCalculator,
    couponCodeDiscountCalculator,
    quantityBasedFreeItemsDiscountCalculator,
    categoryDiscountCalculator
];

List<CartDiscount> cartDiscounts = discountCalculators.Select(discountCalculator => discountCalculator.CalculateDiscount(cart)).OfType<CartDiscount>().ToList();
cart.Discounts = cartDiscounts;

Console.WriteLine(cart.ToString());
Console.ReadKey(true);
