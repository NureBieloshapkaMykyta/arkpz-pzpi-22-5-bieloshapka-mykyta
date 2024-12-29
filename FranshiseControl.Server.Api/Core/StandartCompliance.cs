namespace Core;

public class StandartCompliance
{
    public required long Id { get; set; }
    public required long EstablishmentId { get; set; }
    public required DateTime AuditDate { get; set; }
    public required float Score { get; set; }
    public required string Notes { get; set; }
}
