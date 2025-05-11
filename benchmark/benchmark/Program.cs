using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

[MemoryDiagnoser]
public class SortingBenchmark
{
    private int[] data;

    [Params(10000)] // Egyszerűen bővíthető: 100000, 1000000
    public int DataSize;

    [GlobalSetup]
    public void Setup()
    {
        var rand = new Random(42); // fix seed a reprodukálhatósághoz
        data = Enumerable.Range(0, DataSize).OrderBy(x => rand.Next()).ToArray();
    }

    [Benchmark]
    public void BubbleSort()
    {
        var arr = (int[])data.Clone();
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j + 1])
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
    }

    [Benchmark]
    public void ArraySort()
    {
        var arr = (int[])data.Clone();
        Array.Sort(arr);
    }

    [Benchmark]
    public void LinqOrderBy()
    {
        var arr = data.OrderBy(x => x).ToArray();
    }

    [Benchmark]
    public void CustomQuickSort()
    {
        var arr = (int[])data.Clone();
        QuickSort(arr, 0, arr.Length - 1);
    }

    private void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<SortingBenchmark>();
    }
}
