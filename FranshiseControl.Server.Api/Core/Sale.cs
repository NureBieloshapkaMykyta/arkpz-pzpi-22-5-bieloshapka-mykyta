using Core.Enums;

namespace Core;

public class Sale
{
    public required long Id { get; set; }

    public required DateTime Date { get; set; }
    public required long EstablishmentId { get; set; }

    public required long ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public required int Quantity { get; set; }
    public required PaymentMethod PaymentMethod { get; set; }
}
