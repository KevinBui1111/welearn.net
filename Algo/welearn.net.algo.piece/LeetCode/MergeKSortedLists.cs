using welearn.net.algo.piece.Common;
using welearn.net.algo.piece.Sort;

namespace welearn.net.algo.piece.LeetCode;

public class MergeKSortedLists {
    public ListNode MergeKLists(ListNode?[] lists) {
        ListNode root = null, current = null;
        
        var heap = new BinHeap<ListNode>(
            lists.Where(a => a != null).ToArray(),
            (n1, n2) => n1.val - n2.val
        );
        
        while (!heap.IsEmpty) {
            var max = heap.Peek();
            root ??= current = max; // first time

            var next = max.next;
            current.next = current = max;

            if (next != null) // not reach last
                heap.UpdateRoot(next);
            else // reach end of array
                heap.Pop();
        }

        if (current != null) current.next = null;

        return root;
    }
}