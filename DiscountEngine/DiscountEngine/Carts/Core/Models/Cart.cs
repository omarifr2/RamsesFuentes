namespace DiscountEngine.Carts.Core.Models;

public class Cart(List<CartItem> Items)
{
    public int Id { get; set; }
    public List<CartItem> Items { get; set; } = Items;
    public List<CartDiscount> Discounts { get; set; } = [];
    public decimal Subtotal => Items.Sum(item => item.Product.Price * item.Quantity);
    public decimal Total => Subtotal + Discounts.Sum(discount => discount.Amount);
}
