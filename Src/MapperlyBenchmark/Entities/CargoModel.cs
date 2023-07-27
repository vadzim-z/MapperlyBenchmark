namespace MapperlyBenchmark.Entities;

public class CargoModel
{
    public long Id { get; init; }
    public string ItemNumber { get; init; } = null!;
    public string MaterialDescription { get; init; } = null!;
    public decimal Rate { get; init; }
    public decimal Quantity { get; init; }
    public IEnumerable<InvoiceCostDetail> CostDetails { get; init; } = Array.Empty<InvoiceCostDetail>();
}