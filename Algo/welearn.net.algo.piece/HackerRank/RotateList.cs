using welearn.net.algo.piece.Common;

namespace welearn.net.algo.piece.HackerRank;

public class RotateList {
    //https://leetcode.com/problems/rotate-list/description/

    public static ListNode RotateRight(ListNode head, int k) {
        // l = 5
        // k =1, 2,3,4   5
        // 1 - 2 - 3 - 4 - 5
        // 0   4   3   2   1 <- k % l
        // 5   1   2   3   4 <- l - k % l
        // s = k % l
        // 
        if (head == null || k == 0) return head;
        
        var currentNode = head;
        var listNodes = new List<ListNode>();
        while (currentNode != null) {
            listNodes.Add(currentNode);
            currentNode = currentNode.next;
        }

        var startAt = listNodes.Count - k % listNodes.Count;
        if (startAt == listNodes.Count) return head;

        listNodes[^1].next = head;
        listNodes[startAt - 1].next = null;
        return listNodes[startAt];
    }
}