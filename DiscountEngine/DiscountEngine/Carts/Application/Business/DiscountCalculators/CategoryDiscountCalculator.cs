using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountEngine.Carts.Application.Business.DiscountCalculators
{
    public class CategoryDiscountCalculator(Category category, decimal percentage) : IDiscountCalculator
    {
        private Category category = category;
        private decimal percentage = percentage;

        public CartDiscount CalculateDiscount(Cart cart)
        {
            string description = $"{percentage}% off all products in \"{category}\" category";
            List<CartItem> categoryItems = cart.Items.Where(item => item.Product.Category == category).ToList();
            decimal categoryTotal = categoryItems.Sum(item => item.Product.Price * item.Quantity);
            return new CartDiscount(description, categoryTotal * (percentage / 100m));
        }
    }
}
