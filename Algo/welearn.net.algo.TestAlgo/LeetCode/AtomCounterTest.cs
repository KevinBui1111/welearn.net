using welearn.net.algo.piece.LeetCode;

namespace welearn.net.algo.TestAlgo.LeetCode;

public class AtomCounterTest {
    public static TheoryData<string, string> TestCase =>
        new() {
            { "Ca(OH)2Fe2O3", "CaFe2H2O5" },
            { "H2O", "H2O" },
            { "Mg(OH)2", "H2MgO2" },
            { "K4(ON(SO3)2)2", "K4N2O14S4" },
            { "Be32", "Be32" },
            { "H50", "H50" },
        };

    [Theory]
    [MemberData(nameof(TestCase))]
    public void NumberOfAtom(string formula, string result) {
        Assert.Equal(result, AtomCounter.NumberOfAtom(formula));
    }
}