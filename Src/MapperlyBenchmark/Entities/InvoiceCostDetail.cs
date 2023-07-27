namespace MapperlyBenchmark.Entities;

public class InvoiceCostDetail
{
    public long BookingId { get; set; }
    public string BookingNumber { get; set; } = null!;
    public string Size { get; set; } = null!;
    public string Type { get; set; } = null!;
}