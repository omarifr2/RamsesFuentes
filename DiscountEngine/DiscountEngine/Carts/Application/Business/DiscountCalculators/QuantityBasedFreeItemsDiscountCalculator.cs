using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountEngine.Carts.Application.Business.DiscountCalculators
{
    public class QuantityBasedFreeItemsDiscountCalculator(Product product, int requiredQuantity, int discountQuantity) : IDiscountCalculator
    {
        public CartDiscount? CalculateDiscount(Cart cart)
        {
            int productQuantity = cart.Items.First(item => item.Product.Id == product.Id).Quantity;
            if (productQuantity < requiredQuantity) return null;

            string description = $"Buy {requiredQuantity} get {discountQuantity} free on \"{product.Name}\"";

            if (productQuantity >= requiredQuantity + discountQuantity) return new CartDiscount(description, product.Price * discountQuantity);

            if (productQuantity == requiredQuantity) return new CartDiscount($"{description}, no item to discount", 0);

            int partialDiscountQuantity = productQuantity - requiredQuantity;
            return new CartDiscount($"{description}, only {partialDiscountQuantity} items discounted", product.Price * partialDiscountQuantity);


        }
    }
}
