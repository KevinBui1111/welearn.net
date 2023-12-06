using welearn.net.algo.piece;
using welearn.net.algo.piece.Sort;

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

    [Theory]
    [MemberData(nameof(ArrayTest))]
    public void BuildMinHeap(int[] arr) {
        var heap = new Heap();
        heap.BuildMinHeap(arr);
        AssertHeapMin(arr);
    }

    private static void AssertHeap(int[] arr) {
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

    private static void AssertHeapMin(int[] arr) {
        for (var i = 0; i < arr.Length / 2 - 1; ++i) {
            Assert.True(arr[i] <= arr[2 * i + 1], $"node {i}, compare to left child"); // left child
            Assert.True(arr[i] <= arr[2 * i + 2], $"node {i}, compare to right child"); // right child
        }

        var lastInd = arr.Length - 1;
        if (lastInd > 0)
            Assert.True(arr[lastInd] >= arr[(lastInd - 1) / 2], $"node {lastInd}, compare to parent"); // left child
        if (lastInd > 1)
            Assert.True(arr[lastInd - 1] >= arr[(lastInd - 2) / 2], $"node {lastInd}, compare to parent"); // left child
    }

    [Theory]
    [MemberData(nameof(ArrayTest))]
    public void Sort(int[] arr) {
        var orgArr = (int[])arr.Clone();
        Array.Sort(orgArr);
        
        var heap = new Heap();
        heap.Sort(arr);
        
        Assert.Equal(orgArr, arr);
    }

    [Fact]
    public void BinHeap() {
        int[] arr = { 2, 8, 5, 3, 9, 1 };
        var arr1 = (int[])arr.Clone();
        
        Array.Sort(arr, (a, b) => b - a);
        
        var binHeap = new BinHeap<int>(arr1, (a, b) => b - a);
        var list = new List<int>();
        var v = binHeap.Pop();
        while (v > 0) {
            list.Add(v);
            v = binHeap.Pop();
        }
        
        Assert.Equal(arr, list.ToArray());
    }

    [Fact]
    public void BinHeapMin() {
        int[] arr = { 2, 8, 5, 3, 9, 1 };
        var arr1 = (int[])arr.Clone();
        
        Array.Sort(arr);
        
        var binHeap = new BinHeap<int>(arr1);
        var list = new List<int>();
        var v = binHeap.Pop();
        while (v > 0) {
            list.Add(v);
            v = binHeap.Pop();
        }
        
        Assert.Equal(arr, list.ToArray());
    }
    
    
}