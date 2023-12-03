using welearn.net.algo.piece;

namespace welearn.net.algo.TestAlgo;

public class HeapTest {
    public static IEnumerable<object[]> ArrayTest {
        get {
            yield return new object[] { new[] { 1, 3, 6, 5, 9, 8 } };
            yield return new object[] { new[] { 2, 8, 5, 3, 9, 1 } };
            yield return new object[] { new[] { 1, 2, 3, 4, 5, 6, 7 } };
            yield return new object[] { new[] { 7, 6, 5, 4, 3, 2, 1 } };

            var rnd0 = new Random(0);
            yield return new object[] { GenInts(rnd0) };
            
            yield break;

            int[] GenInts(Random rnd) =>
                Enumerable.Range(1, rnd.Next(50, 100))
                    .Select(_ => rnd.Next(200))
                    .ToArray();
        }
    }

    [Theory]
    [MemberData(nameof(ArrayTest))]
    public void Test(int[] arr) {
        var heap = new Heap();
        heap.BuildMaxHeap(arr);
        AssertHeap(arr);
    }

    [Theory]
    [MemberData(nameof(ArrayTest))]
    public void Test2(int[] arr) {
        var heap = new Heap();
        heap.BuildMaxHeap2(arr);
        AssertHeap(arr);
    }

    private void AssertHeap(int[] arr) {
        for (var i = 0; i < arr.Length / 2 - 1; ++i) {
            Assert.True(arr[i] >= arr[2 * i + 1], $"node {i}, compare to left child"); // left child
            Assert.True(arr[i] >= arr[2 * i + 2], $"node {i}, compare to right child"); // right child
        }

        var lastInd = arr.Length - 1;
        if (lastInd > 0)
            Assert.True(arr[lastInd] <= arr[(lastInd - 1) / 2], $"node {lastInd}, compare to parent"); // left child
        if (lastInd > 1)
            Assert.True(arr[lastInd - 1] <= arr[(lastInd - 2) / 2], $"node {lastInd}, compare to parent"); // left child
    }
}