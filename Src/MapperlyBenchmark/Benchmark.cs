using BenchmarkDotNet.Attributes;
using AutoMapper;
using FizzWare.NBuilder;
using Bogus;
using MapperlyBenchmark.Entities;
using MapperlyBenchmark.Mappers;

public class Benchmark
{
    private IMapper autoMapper;
    private IList<FcrDetail> _fcrDetails;
    private IList<Library> _libraries;
    private IList<CargoModel> _cargoModels;

    [GlobalSetup]
    public void Setup()
    {
        var _faker = new Faker();
        var _builder = new Builder();
        var size = () => _faker.Random.Int(3, 7);
        _fcrDetails = _builder
            .CreateListOfSize<FcrDetail>(size())
            .All()
            .WithFactory(_ => new FcrDetail
            {
                Type = "Fcr"
            })
            .Build();
        _libraries = _builder
            .CreateListOfSize<Library>(size())
            .All()
            .With((x, i) => x.Books = _builder
                .CreateListOfSize<Book>(size())
                .Build())
            .Build();
        _cargoModels = _builder
            .CreateListOfSize<CargoModel>(size())
            .All()
            .WithFactory(() => new CargoModel
            {
                CostDetails = _builder.CreateListOfSize<InvoiceCostDetail>(size())
                    .Build()
            })
            .Build();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ChargeDetailsAutomapper>();
            cfg.AddProfile<CargoAutoMapper>();
            cfg.AddProfile<BookAutomapper>();
            cfg.AddProfile<LibraryAutomapper>();
        });

        autoMapper = configuration.CreateMapper();

        var chargeDetails = ChargeDetailsAutoMapper();
        var chargeDetails2 = ChargeDetailsMapperly();
        var cargoAutoMapper = CargoAutoMapper();
        var cargoMapperly = CargoMapperly();
        var libraryDtos = LibraryAutoMapper();
        var libraryDtos2 = LibraryMapperly();
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsAutoMapper()
    {
        return autoMapper.Map<List<ChargeDetail>>(_fcrDetails);
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsMapperly()
    {
        return _fcrDetails.Select(x => x.MapToChargeDetail()).ToList();
    }

    [Benchmark]
    public List<ChargeItem> CargoAutoMapper()
    {
        return autoMapper.Map<List<ChargeItem>>(_cargoModels);
    }
    
    [Benchmark]
    public List<ChargeItem> CargoMapperly()
    {
        return _cargoModels.Select(x => x.Map()).ToList();
    }

    [Benchmark]
    public List<LibraryDto> LibraryAutoMapper()
    {
        return autoMapper.Map<List<LibraryDto>>(_libraries);
    }

    [Benchmark]
    public IList<LibraryDto> LibraryMapperly()
    {
        return _libraries.Select(x => x.Map()).ToList();
    }
}