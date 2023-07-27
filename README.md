# Mapperly vs AutoMapper Benchmarking

This repository contains benchmarking tests comparing the performance of Mapperly and AutoMapper, two popular object-to-object mapping libraries in .NET.

## Benchmark Results

The benchmarking tests were run using BenchmarkDotNet on a machine with the following specifications:

- CPU: 11th Gen Intel Core i7-1185G7 3.00GHz
- OS: Windows 10
- .NET SDK: 6

The results are as follows:

|                  Method |       Mean |    Error |    StdDev |     Median |
|------------------------ |-----------:|---------:|----------:|-----------:|
| ChargeDetailsAutoMapper |   328.2 ns |  6.62 ns |  16.96 ns |   327.1 ns |
|   ChargeDetailsMapperly |   124.3 ns |  3.08 ns |   8.93 ns |   122.9 ns |
|         CargoAutoMapper | 2,852.7 ns | 87.30 ns | 253.26 ns | 2,786.1 ns |
|           CargoMapperly |   936.9 ns | 28.12 ns |  82.46 ns |   912.4 ns |
|       LibraryAutoMapper |   800.4 ns | 19.86 ns |  57.93 ns |   791.0 ns |
|         LibraryMapperly |   204.8 ns |  4.62 ns |  13.39 ns |   200.0 ns |

The `Mean` column shows the average time taken to run each method. The `Error` column shows half of the 99.9% confidence interval, and the `StdDev` column shows the standard deviation of all measurements.

From these results, we can see that Mapperly is significantly faster than AutoMapper in this benchmark.

Please note that these results are specific to the particular mapping scenario tested, and actual performance may vary depending on the complexity of your objects and mappings.

## Running the Benchmarks

To run the benchmarks yourself, clone this repository and run the following command in the root directory of the project:

```bash
dotnet run -c Release --filter * --project .\Src\MapperlyBenchmark\
