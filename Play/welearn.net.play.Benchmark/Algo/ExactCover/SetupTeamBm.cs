using BenchmarkDotNet.Attributes;
using welearn.net.algo.ExactCover;

namespace welearn.net.play.Benchmark.Algo.ExactCover;

[RPlotExporter]
[MemoryDiagnoser]
public class SetupTeamBm {
    [Benchmark]
    public void SetupTeam_Bm() {
        for (var i = 0; i < 100; ++i) {
            SetupTeam.TestBm();
        }
    }

    [Benchmark]
    public void SetupTeamV1_Bm() {
        for (var i = 0; i < 100; ++i) {
            SetupTeamHashSet.TestBm();
        }
    }
}
