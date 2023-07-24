﻿using BenchmarkDotNet.Attributes;
using AutoMapper;
using FizzWare.NBuilder;
using Bogus;
using MapperlyBenchmark.Entities;
using MapperlyBenchmark.Mappers;

public class Benchmark
{
    private IMapper autoMapper;
    private ChargeDetailsMapperly mapperly;
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

        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ChargeDetailsAutomapper>();
        });

        autoMapper = configuration.CreateMapper();
        mapperly = new ChargeDetailsMapperly();
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsAutoMapperBenchmark()
    {
        return autoMapper.Map<List<ChargeDetail>>(fcrDetails);
    }

    [Benchmark]
    public List<ChargeDetail> ChargeDetailsMapperlyBenchmark()
    {
        return mapperly.FcrDetailToChargeDetail(fcrDetails);
    }
}