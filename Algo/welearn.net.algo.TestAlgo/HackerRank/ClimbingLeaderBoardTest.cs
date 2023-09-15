using System.Reflection;
using welearn.net.algo.piece.HackerRank;
using Xunit.Sdk;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class ClimbingLeaderBoardTest {
    [Theory]
    [InlineData(new[] { 100, 90, 90, 80, 75, 60 },
            new[] { 50, 65, 77, 90, 102 },
            new[] { 6, 5, 4, 2, 1 }
        )
    ]
    [InlineData(new[] { 100, 100, 50, 40, 40, 20, 10 },
            new[] { 5, 25, 50, 120 },
            new[] { 6, 4, 2, 1 }
        )
    ]
    [InlineData(new[] { 1 }, new[] { 1, 1 }, new[] { 1, 1 })]
    [FileData("input06.txt", "output06.txt")]
    [FileData("input08.txt", "output08.txt")]
    [FileData("input09.txt", "output09.txt")]
    [FileData("input10.txt", "output10.txt")]
    public void Test(int[] ranked, int[] player, int[] expected) {
        var actual = ClimbingLeaderBoard.Ranking(ranked.ToList(), player.ToList());
        Assert.Equal(expected, actual);
    }

    private class FileDataAttribute : DataAttribute {
        private readonly string _inputFile;
        private readonly string _expectedFile;

        public FileDataAttribute(string inputFile, string expectedFile) {
            const string path = "HackerRank/TestCase/ClimbingLeaderBoard";
            _inputFile = Path.Combine(path, inputFile);
            _expectedFile = Path.Combine(path, expectedFile);
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod) {
            using var sr = new StreamReader(_inputFile);

            var rankedCount = Convert.ToInt32(sr.ReadLine());
            var ranked = sr.ReadLine()!.TrimEnd().Split(' ')
                .Select(rankedTemp => Convert.ToInt32(rankedTemp))
                .ToArray();

            Assert.Equal(rankedCount, ranked.Length);

            var playerCount = Convert.ToInt32(sr.ReadLine());
            var player = sr.ReadLine()!.TrimEnd().Split(' ')
                .Select(playerTemp => Convert.ToInt32(playerTemp))
                .ToArray();

            Assert.Equal(playerCount, player.Length);

            var expected = File.ReadLines(_expectedFile)
                .Select(s => Convert.ToInt32(s))
                .ToArray();

            yield return new object[] { ranked, player, expected };
        }
    }
}