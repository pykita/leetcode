public class Solution
{
    public Node Connect(Node? root)
    {
        var dictionary = new Dictionary<int, Queue<Node>>();
        AssignNodeIndex(root, 0, dictionary);

        foreach (var kvp in dictionary)
        {
            Link(kvp.Value);
        }

        void Link(Queue<Node> queue)
        {
            var prev = queue.Dequeue();
            while (queue.TryDequeue(out Node? result))
            {
                prev.next = result;
                prev = result;
            }
        }

        return root;
    }

    private void AssignNodeIndex(Node? current, int j, Dictionary<int, Queue<Node>> dictionary)
    {
        if (current == null)
            return;

        if (dictionary.TryGetValue(j + 1, out Queue<Node>? queue))
        {
            queue.Enqueue(current);
        }
        else
        {
            queue = new Queue<Node>();
            queue.Enqueue(current);
            dictionary.Add(j + 1, queue);
        }

        if (current.left != null)
            AssignNodeIndex(current.left, j + 1, dictionary);

        if (current.right != null)
            AssignNodeIndex(current.right, j + 1, dictionary);
    }
}