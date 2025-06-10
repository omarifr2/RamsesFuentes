using DiscountEngine.Carts.Core.Interfaces.Business;
using DiscountEngine.Carts.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountEngine.Carts.Application.Business.DiscountCalculators
{
    public enum CouponCode
    {
        WELCOME10,
        CYBERMONDAY15,
    }

    public class CouponCodeDiscountCalculator : DiscountCalculatorDecorator
    {
        private static Dictionary<CouponCode, IDiscountCalculator> couponCodeDiscountCalculatorsDictionaty = new Dictionary<CouponCode, IDiscountCalculator>
        {
            { CouponCode.WELCOME10, new PercentageDiscountCalculator(10) },
            { CouponCode.CYBERMONDAY15, new CategoryDiscountCalculator(Category.Electronics, 15) },
        };

        private readonly CouponCode couponCode;

        public CouponCodeDiscountCalculator(CouponCode couponCode) : base(couponCodeDiscountCalculatorsDictionaty[couponCode]) 
        {
            this.couponCode = couponCode;
        }

        public override CartDiscount? CalculateDiscount(Cart cart)
        {
            CartDiscount? discount = discountCalculator.CalculateDiscount(cart);
            if (discount is null) return null;
            discount.Description = $"Coupon code: {couponCode} - {discount.Description}";
            return discount;
        }
    }
}
