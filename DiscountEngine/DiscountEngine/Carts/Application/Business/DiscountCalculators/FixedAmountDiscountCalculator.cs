using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountEngine.Carts.Application.Business.DiscountCalculators
{
    public class FixedAmountDiscountCalculator(decimal amount, decimal minimumSubtotal) : IDiscountCalculator
    {
        public CartDiscount? CalculateDiscount(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
