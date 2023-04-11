public class ListNode {
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
      }
 }

public class Solution {
    public ListNode SortList(ListNode head)
    {
        if (head == null)
            return null;
        
        var sd = new PriorityQueue<ListNode, int>();

        var currentHead = head;
        while (currentHead != null)
        {
            sd.Enqueue(currentHead, currentHead.val);
            currentHead = currentHead.next;
        }

        ListNode sortedhead = null, current = null;
        while (sd.Count > 0)
        {
            var node = sd.Dequeue();
            if (current == null)
            {
                current = node;
                sortedhead = node;
                continue;
            }

            current.next = node;
            current = node;
        }

        current.next = null;

        return sortedhead;
    }
}