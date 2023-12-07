using System.Numerics;
using welearn.net.algo.piece.Common;
using welearn.net.algo.piece.HackerRank;

namespace welearn.net.algo.TestAlgo.HackerRank; 

public class RotateListTest {
    
    public static IEnumerable<object[]> TestData {
        get {
            var n5 = new ListNode(1, null);
            var n4 = new ListNode(1, n5);
            var n3 = new ListNode(1, n4);
            var n2 = new ListNode(1, n3);
            var n1 = new ListNode(1, n2);

            return new List<object[]> {
                new object[] { n1, 1, n5 },
                new object[] { n1, 2, n4 },
                new object[] { n1, 3, n3 },
                new object[] { n1, 4, n2 },
                new object[] { n1, 5, n1 },
                new object[] { n1, 100, n1 },
                new object[] { n1, 104, n2 },
            };
        }
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode head, int k, ListNode expected) {
        var actual = RotateList.RotateRight(head, k);
        Assert.Equal(expected, actual);
    }
}