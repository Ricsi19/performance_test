```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3775)
Unknown processor
.NET SDK 9.0.203
  [Host]     : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  DefaultJob : .NET 8.0.15 (8.0.1525.16413), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method          | DataSize | Mean        | Error     | StdDev    | Gen0    | Gen1   | Allocated |
|---------------- |--------- |------------:|----------:|----------:|--------:|-------:|----------:|
| BubbleSort      | 10000    | 74,938.7 μs | 314.81 μs | 262.88 μs |       - |      - |  39.16 KB |
| ArraySort       | 10000    |    366.4 μs |   7.17 μs |   9.81 μs |  5.8594 |      - |  39.09 KB |
| LinqOrderBy     | 10000    |    657.4 μs |  10.61 μs |   8.86 μs | 25.3906 | 5.8594 | 156.52 KB |
| CustomQuickSort | 10000    |    429.8 μs |   5.52 μs |   4.31 μs |  5.8594 |      - |  39.09 KB |
