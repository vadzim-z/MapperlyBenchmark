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
    private IList<CargoModel> _essoRateDetailsModels;

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
        _essoRateDetailsModels = _builder
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
        });

        autoMapper = configuration.CreateMapper();

        var chargeDetails = ChargeDetailsAutoMapper();
        var chargeDetails2 = ChargeDetailsMapperly();
        var essoRateDetailsAutoMapperBenchmark = EssoRateDetailsAutoMapper();
        var essoRateDetailsMapperlyBenchmark = EssoRateDetailsMapperly();
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
    public List<ChargeItem> EssoRateDetailsAutoMapper()
    {
        return autoMapper.Map<List<ChargeItem>>(_essoRateDetailsModels);
    }
    
    [Benchmark]
    public List<ChargeItem> EssoRateDetailsMapperly()
    {
        return _essoRateDetailsModels.Select(x => x.Map()).ToList();
    }
}