using Core.Enums;

namespace Core;

public class Product
{
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required Category Category { get; set; }
    public float Price { get; set; }
    public long SupplierId { get; set; }
    public virtual Supplier? Supplier { get; set; }
}
