using welearn.net.algo.piece.Common;
using welearn.net.algo.piece.LeetCode;

namespace welearn.net.algo.TestAlgo.LeetCode;

public class MergeKSortedListTest {
    public static IEnumerable<object[]> DataTest {
        get {
            yield return new object[] { new[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } } };
        }
    }

    [Theory]
    [MemberData(nameof(DataTest))]
    public void Test(int[]?[] arrays) {
        var arrayList = new List<int>();
        var arrayListNode = new List<ListNode>();
        foreach (var arr in arrays) {
            if (arr != null) {
                arrayList.AddRange(arr);
                arrayListNode.Add(ConvertFromArray(arr));
            }
        }

        arrayList.Sort();
        var expected = ConvertFromArray(arrayList.ToArray());
        var actual = new MergeKSortedLists().MergeKLists(arrayListNode.ToArray());

        Assert.True(ListNode.Equals(expected, actual));
    }

    private ListNode ConvertFromArray(int[] arr) {
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