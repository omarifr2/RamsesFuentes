using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DiscountEngine.Carts.Core.Models;

public class Cart(List<CartItem> Items)
{
    public int Id { get; set; }
    public List<CartItem> Items { get; set; } = Items;
    public List<CartDiscount> Discounts { get; set; } = [];
    public decimal Subtotal => Items.Sum(item => item.Product.Price * item.Quantity);
    public decimal FinalTotal => Subtotal - Discounts.Sum(discount => discount.Amount);

    public override string ToString()
    {
        var toSerialize = new {
            originalTotal = Subtotal,
            discounts = Discounts.Select(discount => new { name = discount.Description, amount = discount.Amount }),
            finalTotal = FinalTotal
        };
        return JsonSerializer.Serialize(toSerialize, new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping });
    }
}
