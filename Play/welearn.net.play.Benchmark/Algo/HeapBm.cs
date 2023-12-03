using BenchmarkDotNet.Attributes;
using welearn.net.algo.piece;
using welearn.net.easy;

namespace welearn.net.play.Benchmark.Algo;

[RPlotExporter]
[MemoryDiagnoser]
public class HeapBm {
    public enum ArrayType {
        Increase,
        Decrease,
        Random
    }

    private Heap _sc;

    [Params(ArrayType.Increase, ArrayType.Decrease, ArrayType.Random)]
    public ArrayType TestArrayType;

    private int[] _testCase;

    [GlobalSetup]
    public void Setup() {
        _sc = new Heap();
        
        var rnd0 = new Random(0);
        _testCase = TestArrayType switch {
            ArrayType.Increase => Enumerable.Range(1, 100_000).ToArray(),
            ArrayType.Decrease => Enumerable.Range(1, 100_000).Reverse().ToArray(),
            ArrayType.Random => Enumerable.Range(1, 100_000).Select(_ => rnd0.Next(10_000)).ToArray(),
            _ => _testCase
        };
    }

    [Benchmark]
    public void BuildMaxHeap() => _sc.BuildMaxHeap(_testCase);

    [Benchmark]
    public void BuildMaxHeap2() => _sc.BuildMaxHeap2(_testCase);
}