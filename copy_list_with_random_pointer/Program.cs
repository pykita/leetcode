// Dmitry

public class Solution {
    public Node? CopyRandomList(Node? head)
    {
        if (head == null)
            return null;

        var originalNodes = new Dictionary<Node, int>();
        var copyNodes = new Dictionary<int, Node>();

        var currentNode = head;
        var currentCopy = new Node(currentNode.val);
        var copyHead = currentCopy;

        int i = 0;
        while (currentNode.next != null)
        {
            copyNodes.Add(i, currentCopy);
            originalNodes.Add(currentNode, i);

            currentNode = currentNode.next;
            currentCopy.next = new Node(currentNode.val);;
            currentCopy = currentCopy.next;

            i++;
        }

        originalNodes.Add(currentNode, i);
        copyNodes.Add(i, currentCopy);

        var originalNodesArray = originalNodes.Keys.ToArray();
        for (int j = 0; j < originalNodesArray.Length; j++)
        {
            if (originalNodesArray[j].random == null)
                continue;

            copyNodes[j].random = copyNodes[originalNodes[originalNodesArray[j].random]];
        }

        return copyHead;
    }
}

public class Node {
    public int val;
    public Node? next;
    public Node? random;

    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}