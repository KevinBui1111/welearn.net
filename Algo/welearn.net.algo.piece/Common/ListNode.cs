namespace welearn.net.algo.piece.Common; 

public class ListNode {
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null) {
        this.val = val;
        this.next = next;
    }

    public static bool Equals(ListNode node1, ListNode node2) {
        while (true) {
            if (node1 == null && node2 != null) return false;
            if (node2 == null && node1 != null) return false;
            if (node2 == null && node1 == null) return true;
            if (node1.val != node2.val) return false;
            
            node1 = node1.next;
            node2 = node2.next;
        }
    }
}