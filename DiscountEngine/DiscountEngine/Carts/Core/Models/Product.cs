﻿namespace DiscountEngine.Carts.Core.Models;

public class Product
{
    public int Id { get; set; }
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Category Category { get; set; } = Category.None;
    public decimal Price { get; set; }
}
