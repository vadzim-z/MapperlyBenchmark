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

    private static ChargeItem.CostDetail MapCostDetail(InvoiceCostDetail costDetail)
        => costDetail.Map();
}

[Mapper]
public static partial class CostDetailMapper
{
    public static ChargeItem.CostDetail Map(this InvoiceCostDetail invoiceCostDetail)
    {
        var costDetail = invoiceCostDetail.MapInternal();
        costDetail.Booking = invoiceCostDetail.MapBooking();
        costDetail.Cbl = invoiceCostDetail.MapCbl();
        costDetail.Equipment = invoiceCostDetail.MapEquipment();
        costDetail.ExportJob = invoiceCostDetail.MapExportJob();

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

[Mapper]
public static partial class CblMapper
{
    [MapProperty(nameof(InvoiceCostDetail.CblId), nameof(ChargeItem.CostDetail.Cbl.CblId))]
    [MapProperty(nameof(InvoiceCostDetail.CblNumber), nameof(ChargeItem.CostDetail.Cbl.CblNumber))]
    public static partial ChargeItem.Cbl MapCbl(
        this InvoiceCostDetail costAndRevenueDetail);
}

[Mapper]
public static partial class ExportJobMapper
{
    [MapProperty(nameof(InvoiceCostDetail.DocumentNumber), nameof(ChargeItem.CostDetail.ExportJob.ExportJobNumber))]
    [MapProperty(nameof(InvoiceCostDetail.DocumentId), nameof(ChargeItem.CostDetail.ExportJob.ExportJobId))]
    public static partial ChargeItem.ExportJob MapExportJob(
        this InvoiceCostDetail costAndRevenueDetail);
}

[Mapper]
public static partial class EquipmentMapper
{
    [MapProperty(nameof(InvoiceCostDetail.EquipmentId), nameof(ChargeItem.CostDetail.Equipment.EquipmentId))]
    [MapProperty(nameof(InvoiceCostDetail.EquipmentNumber), nameof(ChargeItem.CostDetail.Equipment.EquipmentNumber))]
    public static partial ChargeItem.Equipment MapEquipment(
        this InvoiceCostDetail costAndRevenueDetail);
}