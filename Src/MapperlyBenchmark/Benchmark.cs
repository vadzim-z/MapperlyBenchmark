using BenchmarkDotNet.Attributes;
using AutoMapper;
using FizzWare.NBuilder;
using Bogus;
using MapperlyBenchmark.Entities;
using MapperlyBenchmark.Mappers;

public class Benchmark
{
    private IMapper autoMapper;
    private IList<FcrDetail> fcrDetails;

    [GlobalSetup]
    public void Setup()
    {
        var _faker = new Faker();
        var _builder = new Builder();
        var size = _faker.Random.Int(2, 5);
        fcrDetails = _builder
            .CreateListOfSize<FcrDetail>(size)
            .All()
            .WithFactory(_ => new FcrDetail
            {
                Type = "Fcr"
            })
            .Build();
        var libraries = _builder
            .CreateListOfSize<Library>(size)
            .All()
            .With((x, i) => x.Books = _builder
                .CreateListOfSize<Book>(size)
                .Build())
            .Build();

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ChargeDetailsAutomapper>();
        });

        autoMapper = configuration.CreateMapper();

        var chargeDetails = ChargeDetailsAutoMapperBenchmark();
        var chargeDetails2 = ChargeDetailsMapperlyBenchmark();
        var libraryDtos = LibraryMapperlyBenchmark(libraries);
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsAutoMapperBenchmark()
    {
        return autoMapper.Map<List<ChargeDetail>>(fcrDetails);
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsMapperlyBenchmark()
    {
        return fcrDetails.Select(x => x.MapToChargeDetail()).ToList();
    }
    
    [Benchmark]
    public IList<LibraryDto> LibraryMapperlyBenchmark(IList<Library> libraries)
    {
        return libraries.Select(x => x.Map()).ToList();
    }
}