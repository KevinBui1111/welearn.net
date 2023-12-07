using welearn.net.algo.piece.Sort;

namespace welearn.net.algo.TestAlgo.Sort;

public class KWayTest {
    public static IEnumerable<object[]> DataTest {
        get {
            yield return new object[] { new[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } } };
            yield return new object[] { new[] { new[] { 4, 4, 5 }, new[] { 1, 3, 9 }, new[] { 0, 6 } } };
            yield return new object[] { new[] { new[] { 2, 4, 10 }, new[] { 9 }, new[] { 0 } } };
            yield return new object[] { new[] { new[] { 3, 4, 5 }, new[] { 9 }, Array.Empty<int>() } };
            yield return new object[] { new[] { null, new[] { 9 }, Array.Empty<int>() } };
        }
    }

    [Theory]
    [MemberData(nameof(DataTest))]
    public void Test(int[]?[] arrays) {
        var arrayList = new List<int>();
        foreach (var arr in arrays) {
            if (arr != null)
                arrayList.AddRange(arr);
        }

        arrayList.Sort();

        var actual = new KWay().Sort(arrays);

        Assert.Equal(arrayList, actual);
    }
}