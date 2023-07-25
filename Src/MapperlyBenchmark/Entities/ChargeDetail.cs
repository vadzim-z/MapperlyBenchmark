namespace MapperlyBenchmark.Entities;

public class ChargeDetail
{
    public long? Id { get; set; }
    public string Number { get; set; } = null!;
    public string EtDepartureDateEstimated { get; set; } = null!;
    public PrimaryDocumentType Type { get; set; }
    public string EquipmentTransportDocumentNumber { get; set; } = null!;
}

public enum PrimaryDocumentType
{
    Unknown,
    Fcr,
    Cbl,
    Ets,
    To
}