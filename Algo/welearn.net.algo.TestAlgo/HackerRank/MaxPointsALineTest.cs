using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class MaxPointsALineTest {
    public static IEnumerable<object[]> MaxPointsData =>
        new List<object[]> {
            new object[] {
                new[] {
                    new[] { 1, 1 }, new[] { 2, 2 }, new[] { 3, 3 }
                },
                3
            },
            new object[] {
                new[] {
                    new[] { 1, 1 }, new[] { 3, 2 }, new[] { 5, 3 }, new[] { 4, 1 }, new[] { 2, 3 }, new[] { 1, 4 }
                },
                4
            },
            new object[] {
                new[] {
                    new[] { 2, 3 }, new[] { 3, 3 }, new[] { -5, 3 }
                },
                3
            },
            new object[] {
                new[] {
                    new[] { 7, 3 }, new[] { 19, 19 }, new[] { -16, 3 }, new[] { 13, 17 }, new[] { -18, 1 },
                    new[] { -18, -17 }, new[] { 13, -3 }, new[] { 3, 7 }, new[] { -11, 12 }, new[] { 7, 19 },
                    new[] { 19, -12 }, new[] { 20, -18 }, new[] { -16, -15 }, new[] { -10, -15 }, new[] { -16, -18 },
                    new[] { -14, -1 }, new[] { 18, 10 }, new[] { -13, 8 }, new[] { 7, -5 }, new[] { -4, -9 },
                    new[] { -11, 2 }, new[] { -9, -9 }, new[] { -5, -16 }, new[] { 10, 14 }, new[] { -3, 4 },
                    new[] { 1, -20 }, new[] { 2, 16 }, new[] { 0, 14 }, new[] { -14, 5 }, new[] { 15, -11 },
                    new[] { 3, 11 }, new[] { 11, -10 }, new[] { -1, -7 }, new[] { 16, 7 }, new[] { 1, -11 },
                    new[] { -8, -3 }, new[] { 1, -6 }, new[] { 19, 7 }, new[] { 3, 6 }, new[] { -1, -2 },
                    new[] { 7, -3 }, new[] { -6, -8 }, new[] { 7, 1 }, new[] { -15, 12 }, new[] { -17, 9 },
                    new[] { 19, -9 }, new[] { 1, 0 }, new[] { 9, -10 }, new[] { 6, 20 }, new[] { -12, -4 },
                    new[] { -16, -17 }, new[] { 14, 3 }, new[] { 0, -1 }, new[] { -18, 9 }, new[] { -15, 15 },
                    new[] { -3, -15 }, new[] { -5, 20 }, new[] { 15, -14 }, new[] { 9, -17 }, new[] { 10, -14 },
                    new[] { -7, -11 }, new[] { 14, 9 }, new[] { 1, -1 }, new[] { 15, 12 }, new[] { -5, -1 },
                    new[] { -17, -5 }, new[] { 15, -2 }, new[] { -12, 11 }, new[] { 19, -18 }, new[] { 8, 7 },
                    new[] { -5, -3 }, new[] { -17, -1 }, new[] { -18, 13 }, new[] { 15, -3 }, new[] { 4, 18 },
                    new[] { -14, -15 }, new[] { 15, 8 }, new[] { -18, -12 }, new[] { -15, 19 }, new[] { -9, 16 },
                    new[] { -9, 14 }, new[] { -12, -14 }, new[] { -2, -20 }, new[] { -3, -13 }, new[] { 10, -7 },
                    new[] { -2, -10 }, new[] { 9, 10 }, new[] { -1, 7 }, new[] { -17, -6 }, new[] { -15, 20 },
                    new[] { 5, -17 }, new[] { 6, -6 }
                },
                6
            }
        };

    [Theory]
    [MemberData(nameof(MaxPointsData))]
    public void Test(int[][] points, int expected) {
        var actual = MaxPointsALine.MaxPoints(points);
        Assert.Equal(expected, actual);
    }
}