using welearn.net.algo.piece;

namespace welearn.net.algo.TestAlgo;

public class RotateImageTest {
    [Theory]
    [MemberData(nameof(InputTest))]
    public void TestRotate90Clockwise(int[][] matrix, int[][] expected) {
        RotateImage.Rotate90Clockwise(matrix);
        Assert.Equal(expected, matrix);
    }

    public static IEnumerable<object[]> InputTest {
        get {
            var input = new[] {
                new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 }
            };
            var expect = new[] {
                new[] { 7, 4, 1 }, new[] { 8, 5, 2 }, new[] { 9, 6, 3 }
            };

            yield return new object[] { input, expect };

            input = new[] {
                new[] { 5, 1, 9, 11 }, new[] { 2, 4, 8, 10 }, new[] { 13, 3, 6, 7 }, new[] { 15, 14, 12, 16 }
            };
            expect = new[] {
                new[] { 15, 13, 2, 5 }, new[] { 14, 3, 4, 1 }, new[] { 12, 6, 8, 9 }, new[] { 16, 7, 10, 11 }
            };

            yield return new object[] { input, expect };
        }
    }
}