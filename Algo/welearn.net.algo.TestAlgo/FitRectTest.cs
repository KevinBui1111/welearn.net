using welearn.net.algo.piece.Common.Geo;
using welearn.net.algo.piece.FitRectangle;
using Xunit.Sdk;

namespace welearn.net.algo.TestAlgo;

public class FitRectTest {
    public static IEnumerable<object[]> DataTest {
        get {
            const string boundary = "10 10";
            var rects = new List<Rectangle> {
                "0 7 4 2",
                "4 10 4 2",
                "6 5 3 4",
                "2 4 1 4"
            };

            yield return new object[] { rects, boundary, "1 10", "9 10" };
            yield return new object[] { rects, boundary, "4 2", "0 10" };
            yield return new object[] { rects, boundary, "5 2", "4 8" };
            yield return new object[] { rects, boundary, "7 1", "0 8" };
            yield return new object[] { rects, boundary, "3 5", "3 5" };

            var rects2 = new List<Rectangle>(rects);
            rects2.AddRange( new List<Rectangle> {
                "3 4 2 1",
                "6 8 4 2"
            });
            yield return new object[] { rects2, boundary, "1 8", "5 8" };
            yield return new object[] { rects2, boundary, "7 1", "3 1" };
        }
    }

    [Theory]
    [MemberData(nameof(DataTest))]
    public void Find(List<Rectangle> rects, Size boundary, Size searchRect, Point expected) {
        var fitRect = new FitRect(rects, boundary);
        var point = fitRect.Find(searchRect);
        Assert.Equal(expected, point);
    }

    public static void Test() {
        foreach (var test in DataTest) {
            var rects = (List<Rectangle>)test[0];
            Size boundary = (string)test[1];
            Size searchRect = (string)test[2];
            Point expected = (string)test[3];
            
            var fitRect = new FitRect(rects, boundary);
            var point = fitRect.Find(searchRect);

            try {
                Assert.Equal(expected, point);}
            catch (EqualException e) {
                Console.WriteLine(e.Message);

                Console.WriteLine();
            }
        }
    }
}