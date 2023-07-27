namespace MapperlyBenchmark.Entities;

public class InvoiceCostDetail
{
    public long BookingId { get; set; }
    public string BookingNumber { get; set; } = null!;
    public string Size { get; set; } = null!;
    public string Type { get; set; } = null!;
    public long? DocumentId { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public long? EquipmentId { get; set; } = null!;
    public string EquipmentNumber { get; set; } = null!;
    public long? CblId { get; set; } = null!;
    public string CblNumber { get; set; } = null!;
}