namespace welearn.net.algo.piece.LangfordSequence; 

public class LangfordTest : ITestPiece{
    public void Test() {
        var lfpV2 = new LangfordPairing_v2 {
            StopAtFirst = true
        };
        foreach (var i in Enumerable.Range(1, 33)) {
            var nSolution = lfpV2.Arrange(i);
            Console.WriteLine($"Solution for {i}: {nSolution}");
        }
    }
}