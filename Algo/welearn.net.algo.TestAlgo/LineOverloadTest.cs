using welearn.net.algo.piece;

namespace welearn.net.algo.TestAlgo;

public class LineOverloadTest {
    public static IEnumerable<object[]> DataTest {
        get {
            var segmentThickString = "3 1 5 2 8 3 10 2 15 2 20";

            yield return new object[] {
                segmentThickString,
                "2 3",
                "2 1 3 1 5 2 8 3 10 2 15 2 20"
            };
            
            yield return new object[] {
                segmentThickString,
                "2 4",
                "2 1 3 2 4 1 5 2 8 3 10 2 15 2 20"
            };
            
            yield return new object[] {
                segmentThickString,
                "2 5",
                "2 1 3 2 5 2 8 3 10 2 15 2 20"
            };
            
            yield return new object[] {
                segmentThickString,
                "2 22",
                "2 1 3 2 5 3 8 4 10 3 15 3 20 1 22"
            };
            
            yield return new object[] {
                segmentThickString,
                "2 7",
                "2 1 3 2 5 3 7 2 8 3 10 2 15 2 20"
            };
        }
    }

    

    private int[] ConvertLine(string lineString) {
        var parts = lineString.Split(' ')
            .Select(int.Parse)
            .ToArray();
        if (parts.Length != 2) throw new InvalidDataException();
        return parts;
    }

    [Theory]
    [MemberData(nameof(DataTest))]
    public void Test(string segmentThickString, string lineString, string resultString) {
        var segmentThick = LineOverload.Segment.ConstructSegmentThick(segmentThickString);
        var expected = LineOverload.Segment.ConstructSegmentThick(resultString);
        int[] line = ConvertLine(lineString);
        
        var actual = LineOverload.AppendLine(line, segmentThick);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("3 1 5 2 8 3 10 2 15 2 20")]
    public void SegmentThick2StringTest(string input) {
        var segmentThick = LineOverload.Segment.ConstructSegmentThick(input);
        var backToString = LineOverload.SegmentThick2String(segmentThick);
        Assert.Equal(input, backToString);
    }

    [Theory]
    [InlineData("5 2 10", "1 1 3",  "5 2 10")]
    [InlineData("5 2 10", "1 1 5",  "5 2 10")]
    [InlineData("5 2 10", "1 1 7",  "5 3 7 2 10")]
    [InlineData("5 2 10", "1 1 10", "5 3 10")]
    [InlineData("5 2 10", "1 1 13", "5 3 10")]

    [InlineData("5 2 10", "5 1 7",  "5 3 7 2 10")]
    [InlineData("5 2 10", "5 1 10", "5 3 10")]
    [InlineData("5 2 10", "5 1 13", "5 3 10")]

    [InlineData("5 2 10", "6 1 7",  "5 2 6 3 7 2 10")]
    [InlineData("5 2 10", "6 1 10", "5 2 6 3 10")]
    [InlineData("5 2 10", "6 1 13", "5 2 6 3 10")]
    public void MergeTwoSegmentTest(string seg1, string seg2, string expected) {
        var segment1 = new LineOverload.Segment(seg1);
        var segment2 = new LineOverload.Segment(seg2);
        var expectedSegs = LineOverload.Segment.ConstructSegmentThick(expected);

        var actual = LineOverload.MergeTwoSegment(segment1, segment2);
        Assert.Equal(expectedSegs, actual);
    }

    public static void test() {
        var test = DataTest.ToArray()[3].Select(o => (string)o).ToArray();

        var testInstance = new LineOverloadTest();
        testInstance.Test(test[0], test[1], test[2]);

        // foreach (var testCase in DataTest) {
        //     var test = testCase.Select(o => (string)o).ToArray();
        //     testInstance.Test(test[0], test[1], test[2]);
        // }
    }
}