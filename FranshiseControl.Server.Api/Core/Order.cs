using Core.Enums;

namespace Core;

public class Order
{
    public required long Id { get; set; }
    public required int Quantity { get; set; }
    public required DateTime OrderDate { get; set; }
    public required DateTime DeliveryDate { get; set; }
    public required OrderStatus Status { get; set; }
    public required long EstablishmentId { get; set; }
    public virtual Establishment? Establishment { get; set; }

    public required long ProductId { get; set; }
    public virtual Product? Product { get; set; }
}
