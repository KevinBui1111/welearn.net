using BenchmarkDotNet.Attributes;
using welearn.net.algo.piece.Combinatorics;

namespace welearn.net.play.Benchmark.Algo;

[RPlotExporter]
[MemoryDiagnoser(false)]
public class Combinatorics {
    private Permutation _permutation;
    [Params(4, 6, 8)] public int _n;

    private byte[] _testArray;

    [GlobalSetup]
    public void Setup() {
        _testArray = Enumerable.Range(1, _n).Select(i => (byte)i).ToArray();
        _permutation = new Permutation();
    }

    [Benchmark]
    public IList<IList<byte>> Permutation() {
        return _permutation.Permute(_testArray);
    }

    [Benchmark]
    public IList<IList<byte>> PermutationHeap() {
        return _permutation.PermuteHeap(_testArray);
    }
}