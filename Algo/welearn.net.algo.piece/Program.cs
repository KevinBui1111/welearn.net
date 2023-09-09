// See https://aka.ms/new-console-template for more information

using welearn.net.algo.piece;

// HundredPrisoners.Test();
// RandomDistribute.TestRandomDistribute();
foreach (var i in Enumerable.Range(2, 16)) {
    var nSolution = new LangfordPairing().Arrange(i);
    Console.WriteLine($"Solution for {i}: {nSolution}");
}