using MapperlyBenchmark.Entities;
using Riok.Mapperly.Abstractions;

namespace MapperlyBenchmark.Mappers;

[Mapper(PropertyNameMappingStrategy = PropertyNameMappingStrategy.CaseInsensitive)]
public static partial class CargoMapper
{
    [MapProperty(nameof(CargoModel.Id),
        nameof(ChargeItem.DetailId))]
    [MapProperty(nameof(CargoModel.ItemNumber),
        nameof(ChargeItem.ItemNumber))]
    [MapProperty(nameof(CargoModel.Quantity),
        nameof(ChargeItem.ChargeQuantity))]
    [MapProperty(nameof(CargoModel.Rate),
        nameof(ChargeItem.ChargeRate))]
    [MapProperty(nameof(CargoModel.MaterialDescription),
        nameof(ChargeItem.TypeName))]
    [MapProperty(nameof(CargoModel.CostDetails),
        nameof(ChargeItem.CostDetails))]
    public static partial ChargeItem Map(this CargoModel cargo);

    private static ChargeItem.CostDetail MapCostAndRevenueDetail(InvoiceCostDetail costDetail)
        => costDetail.Map();
}

[Mapper]
public static partial class CostDetailMapper
{
    public static ChargeItem.CostDetail Map(this InvoiceCostDetail invoiceCostDetail)
    {
        var costDetail = invoiceCostDetail.MapInternal();
        costDetail.Booking = invoiceCostDetail.MapBooking();

        return costDetail;
    }

    private static partial ChargeItem.CostDetail MapInternal(this InvoiceCostDetail costDetail);
}

[Mapper]
public static partial class BookingMapper
{
    [MapProperty(nameof(InvoiceCostDetail.BookingId), nameof(ChargeItem.Booking.BookingId))]
    [MapProperty(nameof(InvoiceCostDetail.BookingNumber), nameof(ChargeItem.Booking.BookingNumber))]
    public static partial ChargeItem.Booking MapBooking(
        this InvoiceCostDetail costDetail);
}