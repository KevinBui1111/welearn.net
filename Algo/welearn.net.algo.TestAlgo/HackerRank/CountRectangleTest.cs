using System.Drawing;
using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank;

public class CountRectangleTest
{
    public static IEnumerable<object[]> DataTest {
        get
        {
            var points = new List<Point>
            {
                new(5, 10),
                new(7, 10),
                new(11, 10),
                new(5, 7),
                new(7, 7),
                new(11, 7),
                new(11, 11),
            };

            yield return new object[] { points, 3 };
            
            yield return new object[] { new List<Point>
            {
                new(5, 10),
                new(7, 10),
                new(11, 10),
                
                new(5, 7),
                new(7, 7),
                new(11, 7),
                
                new(5, 5),
                new(7, 5),
                new(11, 5),
                
                new(11, 11),
            }, 9 };
        }
    }

    [Theory]
    [MemberData(nameof(DataTest))]
    public void Test(List<Point> input, int expected) {
        var actual = CountRectangle.NumberOfRectangle(input);
        Assert.Equal(expected, actual);
    }
}