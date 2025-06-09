using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountEngine.Carts.Core.Models
{
    public class CartDiscount(string name, decimal amount)
    {
        public string Description { get; set; } = name;

        public decimal Amount { get; set; } = amount;
    }
}
