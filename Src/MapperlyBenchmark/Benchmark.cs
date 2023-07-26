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

    [GlobalSetup]
    public void Setup()
    {
        var _faker = new Faker();
        var _builder = new Builder();
        var size = _faker.Random.Int(2, 5);
        _fcrDetails = _builder
            .CreateListOfSize<FcrDetail>(size)
            .All()
            .WithFactory(_ => new FcrDetail
            {
                Type = "Fcr"
            })
            .Build();
        _libraries = _builder
            .CreateListOfSize<Library>(size)
            .All()
            .With((x, i) => x.Books = _builder
                .CreateListOfSize<Book>(size)
                .Build())
            .Build();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ChargeDetailsAutomapper>();
            cfg.AddProfile<BookAutomapper>();
            cfg.AddProfile<LibraryAutomapper>();
        });

        autoMapper = configuration.CreateMapper();

        var chargeDetails = ChargeDetailsAutoMapperBenchmark();
        var chargeDetails2 = ChargeDetailsMapperlyBenchmark();
        var libraryDtos = LibraryAutoMapperBenchmark();
        var libraryDtos2 = LibraryMapperlyBenchmark();
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsAutoMapperBenchmark()
    {
        return autoMapper.Map<List<ChargeDetail>>(_fcrDetails);
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsMapperlyBenchmark()
    {
        return _fcrDetails.Select(x => x.MapToChargeDetail()).ToList();
    }
    
    [Benchmark]
    public IList<LibraryDto> LibraryMapperlyBenchmark()
    {
        return _libraries.Select(x => x.Map()).ToList();
    }

    [Benchmark]
    public List<LibraryDto> LibraryAutoMapperBenchmark()
    {
        return autoMapper.Map<List<LibraryDto>>(_libraries);
    }
}