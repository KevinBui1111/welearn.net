using BenchmarkDotNet.Attributes;
using welearn.net.algo.piece.Combinatorics;
using welearn.net.algo.piece.HackerRank;

namespace welearn.net.play.Benchmark.LeetCode; 

[RPlotExporter]
[MemoryDiagnoser(false)]
public class SelfCrossingBm {
    private SelfCrossing _sc;
    private SelfCrossing2 _sc2;
    [Params(0, 1)] public int _n;

    private int[][] _testCase;

    [GlobalSetup]
    public void Setup() {
        var testData = new List<int[][]> {
            new[] {
                Enumerable.Range(1, 100_000).ToArray()
            },
            new[] {
                new[] { 2, 1, 1, 2 },
                new[] { 1, 1, 2, 3, 7, 8, 4, 7, 3, 6, 2, 5, 2 }
            }
        };

        _testCase = testData[_n];
        _sc = new SelfCrossing();
        _sc2 = new SelfCrossing2();
    }

    [Benchmark]
    public void IsSelfCrossing() {
        foreach (var points in _testCase) {
            _sc2.IsSelfCrossing2(points);
        }
    }

    [Benchmark]
    public void IsSelfCrossing2() {
        foreach (var points in _testCase) {
            _sc.IsSelfCrossing2(points);
        }
    }
}