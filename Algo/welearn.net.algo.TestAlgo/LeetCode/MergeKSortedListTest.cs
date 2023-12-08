using welearn.net.algo.piece.Common;
using welearn.net.algo.piece.LeetCode;

namespace welearn.net.algo.TestAlgo.LeetCode;

public class MergeKSortedListTest {
    public static IEnumerable<object[]> DataTest {
        get {
            // yield return new object[] { new[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } } };

            var rnd19 = new Random(19);
            // var data = Enumerable.Range(1, 100_000)
            //     .Select(_ => Enumerable.Range(1, rnd19.Next(800, 1000))
            //         .Select(_ => rnd19.Next(10_000))
            //         .OrderBy(n => n)
            //         .ToArray()
            //     )
            //     .ToArray()
            //     ;
            // yield return new object[] { data };

            yield return new object[] {
                Enumerable.Range(1, 100_000)
                    .Select(_ => Enumerable.Range(1, rnd19.Next(800, 1000))
                        .Select(_ => rnd19.Next(10_000))
                        .OrderBy(n => n)
                        .ToArray())
                    .Select(ConvertFromArray)
                    .ToArray()
            };
        }
    }

    [Theory(Skip = "Omit")]
    [MemberData(nameof(DataTest))]
    public void MergeKLists(int[]?[] arrays) {
        var (expected, input) = PrepareListNode(arrays);
        var actual = new MergeKSortedLists().MergeKLists(input);
        Assert.True(ListNode.Equals(expected, actual));
    }

    [Theory(Skip = "Omit")]
    [MemberData(nameof(DataTest))]
    public void MergeKLists3(int[]?[] arrays) {
        var (expected, input) = PrepareListNode(arrays);
        var actual = new MergeKSortedLists().MergeKLists3(input);
        Assert.True(ListNode.Equals(expected, actual));
    }
    
    [Theory]
    [MemberData(nameof(DataTest))]
    public void MergeKListsListNode(ListNode[] arrays) {
        new MergeKSortedLists().MergeKLists(arrays);
    }

    [Theory]
    [MemberData(nameof(DataTest))]
    public void MergeKListsListNode3(ListNode[] arrays) {
        new MergeKSortedLists().MergeKLists3(arrays);
    }

    private static (ListNode expected, ListNode[] input) PrepareListNode(int[]?[] arrays) {
        var arrayList = new List<int>();
        var arrayListNode = new List<ListNode>();
        foreach (var arr in arrays) {
            if (arr == null) continue;
            arrayList.AddRange(arr);
            arrayListNode.Add(ConvertFromArray(arr));
        }

        arrayList.Sort();
        return (ConvertFromArray(arrayList.ToArray()),
                arrayListNode.ToArray()
            );
    }

    private static ListNode ConvertFromArray(int[] arr) {
        ListNode root = null, current = null;
        foreach (var a in arr) {
            var newNode = new ListNode(a);
            if (root == null) root = current = newNode;
            else
                current = current.next = newNode;
        }

        return root;
    }
}