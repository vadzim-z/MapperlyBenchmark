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
        public Equipment Equipment { get; set; } = null!;
        public ExportJob ExportJob { get; set; } = null!;
        public Cbl Cbl { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Type { get; set; } = null!;
    }

    public class Booking
    {
        public long? BookingId { get; init; }
        public string BookingNumber { get; init; } = null!;
    }

    public class Cbl
    {
        public long? CblId { get; init; }
        public string CblNumber { get; init; } = null!;
    }

    public class Equipment
    {
        public long? EquipmentId { get; init; }
        public string EquipmentNumber { get; init; } = null!;
    }

    public class ExportJob
    {
        public long? ExportJobId { get; init; }
        public string ExportJobNumber { get; init; } = null!;
    }
}