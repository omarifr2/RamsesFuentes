using DiscountEngine.Carts.Core.Models;

namespace DiscountEngine.Carts.Core.Interfaces.Business
{
    public interface IDiscountCalculator
    {
        CartDiscount CalculateDiscount(Cart cart);
    }
}
