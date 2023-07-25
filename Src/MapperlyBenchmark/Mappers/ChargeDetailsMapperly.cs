using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public static partial class ChargeDetailsMapperly
{
    [MapProperty(nameof(FcrDetail.FcrId), nameof(ChargeDetail.Id))]
    [MapProperty(nameof(FcrDetail.FcrNumber), nameof(ChargeDetail.Number))]
    [MapProperty(nameof(FcrDetail.Etd), nameof(ChargeDetail.EtDepartureDateEstimated))]
    public static partial ChargeDetail MapToChargeDetail(this FcrDetail fcrDetail);
}