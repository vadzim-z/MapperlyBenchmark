namespace MapperlyBenchmark.Entities;

public class ChargeDetail
{
    public long? Id { get; init; }
    public string Number { get; init; } = null!;
    public string EtDepartureDateEstimated { get; set; } = null!;
    public PrimaryDocumentType Type { get; set; }
    public string EquipmentTransportDocumentNumber { get; init; } = null!;
}

public enum PrimaryDocumentType
{
    Unknown,
    Fcr,
    Cbl,
    Ets,
    To
}