public class Solution {
    public ListNode OddEvenList(ListNode? head)
    {
        if (head?.next?.next == default)
            return head;
        
        var currentHead = head;
        ListNode currentHeadOdd = currentHead, startOdd = currentHead;
        ListNode currentHeadEven = currentHead.next, startEven = currentHead.next;
        currentHead = currentHead.next.next;

        while (currentHead.next is { next: { } })
        {
            currentHeadOdd.next = currentHead;
            currentHeadOdd = currentHeadOdd.next;
            
            currentHeadEven.next = currentHead.next;
            currentHeadEven = currentHeadEven.next;
            
            currentHead = currentHead.next.next;
        }

        currentHeadEven.next = currentHead.next;

        currentHead.next = startEven;
        currentHeadOdd.next = currentHead;

        return startOdd;
    }
}