using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper]
public partial class ChargeDetailsMapperly
{
    [MapProperty(nameof(FcrDetail.FcrId),
        nameof(ChargeDetail.Id))]
    [MapProperty(nameof(FcrDetail.FcrNumber),
        nameof(ChargeDetail.Number))]
    public partial List<ChargeDetail> FcrDetailToChargeDetail(
        IList<FcrDetail> fcrDetail);
}