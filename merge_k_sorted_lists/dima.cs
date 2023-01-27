public class Solution {
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (!lists.Any())
            return null;
        
        var allNumbers = new List<int>();
        for (int i = 0; i < lists.Length; i++)
        {
            while (lists[i] != null)
            {
                allNumbers.Add(lists[i] .val);
                lists[i] = lists[i].next;
            }
        }

        if (!allNumbers.Any())
            return null;

        allNumbers.Sort();

        var root = new ListNode(allNumbers[0]);
        var current = root;

        for (int i = 1; i < allNumbers.Count; i++)
        {
            current.next = new ListNode(allNumbers[i]);
            current = current.next;
        }

        return root;
    }
}