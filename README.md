```
more reasons to use dotnet 10 ,
more reasons to use AES as you standard
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
Intel Core i7-8650U CPU 1.90GHz (Max: 2.11GHz) (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.100
  [Host]     : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v3


```
| Method        | Mean     | Error     | StdDev    | Rank | Gen0   | Allocated |
|-------------- |---------:|----------:|----------:|-----:|-------:|----------:|
| AesEncryptIon | 2.898 μs | 0.2546 μs | 0.7508 μs |    1 | 0.1564 |     664 B |
| AesDecryption | 2.882 μs | 0.2674 μs | 0.7841 μs |    1 | 0.1678 |     704 B |
| DesEncryption | 6.847 μs | 0.5606 μs | 1.6529 μs |    2 | 0.2289 |     968 B |
| DesDecryption |       NA |        NA |        NA |    ? |     NA |        NA |

Benchmarks with issues:
  AesBenchmarks.DesDecryption: DefaultJob
