using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountEngine.Carts.Core.Models
{
    public class CartDiscount
    {
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
    }
}
