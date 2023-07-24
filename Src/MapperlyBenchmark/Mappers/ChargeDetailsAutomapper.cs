using AutoMapper;
using MapperlyBenchmark.Entities;

namespace MapperlyBenchmark.Mappers;

public class ChargeDetailsAutomapper : Profile
{
    public ChargeDetailsAutomapper()
    {
        CreateMap<FcrDetail, ChargeDetail>()
            .ForMember(dest => dest.Id, act => act.MapFrom(src => src.FcrId))
            .ForMember(dest => dest.Number, act => act.MapFrom(src => src.FcrNumber))
            .ForMember(dest => dest.EtDepartureDateEstimated, act => act.MapFrom(src => src.Etd));
    }
}