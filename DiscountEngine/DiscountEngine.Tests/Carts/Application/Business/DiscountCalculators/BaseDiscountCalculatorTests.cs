using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Tests.Carts.Application.Business.DiscountCalculators
{
    public class BaseDiscountCalculatorTests
    {
        protected Cart TestCart { get; set; }
        protected decimal TestCartSubtotal {  get; set; }

        // Electronics
        protected Product smartphone = new Product { Id = 1, Sku = "ELEC001", Name = "Smartphone", Category = Category.Electronics, Price = 699.99m };
        protected Product bluetoothHeadphones = new Product { Id = 5, Sku = "ELEC002", Name = "Bluetooth Headphones", Category = Category.Electronics, Price = 49.99m };
        protected Product laptop = new Product { Id = 9, Sku = "ELEC003", Name = "Laptop", Category = Category.Electronics, Price = 1200.00m };

        // Baby
        protected Product diapersSizeM = new Product { Id = 2, Sku = "BABY001", Name = "Diapers Size M", Category = Category.Baby, Price = 15.49m };
        protected Product babyWipes = new Product { Id = 7, Sku = "BABY002", Name = "Baby Wipes", Category = Category.Baby, Price = 3.49m };

        // Groceries
        protected Product oatmealCereal = new Product { Id = 3, Sku = "GROC001", Name = "Oatmeal Cereal", Category = Category.Groceries, Price = 4.99m };
        protected Product wholeMilk = new Product { Id = 6, Sku = "GROC002", Name = "Whole Milk", Category = Category.Groceries, Price = 1.79m };
        protected Product wholeWheatPasta = new Product { Id = 10, Sku = "GROC003", Name = "Whole Wheat Pasta", Category = Category.Groceries, Price = 2.39m };

        // Meats
        protected Product chickenBreast = new Product { Id = 4, Sku = "MEAT001", Name = "Chicken Breast", Category = Category.Meats, Price = 7.89m };
        protected Product groundBeef = new Product { Id = 8, Sku = "MEAT002", Name = "Ground Beef", Category = Category.Meats, Price = 9.25m };


        public BaseDiscountCalculatorTests()
        {

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

            TestCart = new Cart(cartItems);
            TestCartSubtotal = 2102.11m;
        }
    }
}
