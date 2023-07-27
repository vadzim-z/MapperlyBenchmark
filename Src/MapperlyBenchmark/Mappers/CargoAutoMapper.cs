using AutoMapper;
using MapperlyBenchmark.Entities;

namespace MapperlyBenchmark.Mappers;

public class CargoAutoMapper : Profile
{
    public CargoAutoMapper()
    {
        CreateMap<CargoModel, ChargeItem>()
            .ForMember(dest => dest.DetailId, act => act.MapFrom(src => src.Id))
            .ForMember(dest => dest.ItemNumber, act => act.MapFrom(src => src.ItemNumber))
            .ForMember(dest => dest.ChargeQuantity, act => act.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.ChargeRate, act => act.MapFrom(src => src.Rate))
            .ForMember(dest => dest.TypeName, act => act.MapFrom(src => src.MaterialDescription));

        CreateMap<InvoiceCostDetail, ChargeItem.CostDetail>()
            .ForPath(dest => dest.Booking.BookingId, act => act.MapFrom(src => src.BookingId))
            .ForPath(dest => dest.Booking.BookingNumber, act => act.MapFrom(src => src.BookingNumber));
    }
}