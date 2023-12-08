using welearn.net.algo.piece.Common;
using welearn.net.algo.piece.Sort;

namespace welearn.net.algo.piece.LeetCode;

public class MergeKSortedLists {
    public ListNode MergeKLists(ListNode?[] lists) {
        ListNode root = new(), current = root;
        
        var heap = new BinHeap<ListNode>(
            lists.Where(a => a != null).ToArray(),
            (n1, n2) => n1.val - n2.val
        );
        
        while (!heap.IsEmpty) {
            var max = heap.Peek();

            var next = max.next;
            current.next = current = max;

            if (next != null) // not reach last
                heap.UpdateRoot(next);
            else // reach end of array
                heap.Pop();
        }

        if (current != null) current.next = null;

        return root.next;
    }

    //https://leetcode.com/problems/merge-k-sorted-lists/solutions/3232932/very-simple-priorityqueue-solution-beats-83/
    public ListNode MergeKLists3(ListNode[] lists) {
        var pq = new PriorityQueue<ListNode, int>();

        foreach (var node in lists)
            if (node != null)
                pq.Enqueue(node, node.val);

        ListNode root = new(), current = root;

        while (pq.Count > 0) {
            var node = pq.Dequeue();

            if (node.next != null)
                pq.Enqueue(node.next, node.next.val);

            current = current.next = new ListNode(node.val);
        }

        return root.next;
    }
}