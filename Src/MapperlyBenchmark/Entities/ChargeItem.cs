namespace MapperlyBenchmark.Entities;

public class ChargeItem
{
    public string DetailId { get; init; } = null!;
    public string ItemNumber { get; init; } = null!;
    public string TypeName { get; init; } = null!;
    public decimal ChargeRate { get; init; }
    public decimal ChargeQuantity { get; init; }

    public ICollection<CostDetail> CostDetails { get; set; } = Array.Empty<CostDetail>();

    public class CostDetail
    {
        public Booking Booking { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Type { get; set; } = null!;
    }

    public class Booking
    {
        public long? BookingId { get; init; }
        public string BookingNumber { get; init; } = null!;
    }
}