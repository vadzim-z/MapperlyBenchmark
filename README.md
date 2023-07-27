# Mapperly vs AutoMapper Benchmarking

This repository contains benchmarking tests comparing the performance of Mapperly and AutoMapper, two popular object-to-object mapping libraries in .NET.

## Benchmark Results

The benchmarking tests were run using BenchmarkDotNet on a machine with the following specifications:

- CPU: 11th Gen Intel Core i7-1185G7 3.00GHz
- OS: Windows 10
- .NET SDK: 6

The results are as follows:

|                  Method |     Mean |    Error |   StdDev |
|------------------------ |---------:|---------:|---------:|
| ChargeDetailsAutoMapper | 609.4 ns | 11.95 ns | 20.94 ns |
|   ChargeDetailsMapperly | 117.9 ns |  2.41 ns |  4.71 ns |
|         CargoAutoMapper | 915.0 ns | 18.05 ns | 27.57 ns |
|           CargoMapperly | 756.1 ns | 15.04 ns | 32.38 ns |

The `Mean` column shows the average time taken to run each method. The `Error` column shows half of the 99.9% confidence interval, and the `StdDev` column shows the standard deviation of all measurements.

From these results, we can see that Mapperly is significantly faster than AutoMapper in this benchmark.

Please note that these results are specific to the particular mapping scenario tested, and actual performance may vary depending on the complexity of your objects and mappings.

## Running the Benchmarks

To run the benchmarks yourself, clone this repository and run the following command in the root directory of the project:

```bash
dotnet run -c Release --filter * --project .\Src\MapperlyBenchmark\
