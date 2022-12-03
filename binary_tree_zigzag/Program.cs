TreeNode t = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7)));

var res = new Solution().ZigzagLevelOrder(t);

Console.WriteLine();

public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode? root)
    {
        if (root == null)
            return new List<IList<int>>();

        var dictionary = new Dictionary<int, IList<int>>();
        var queue = new Queue<(int level, TreeNode node)>();
        queue.Enqueue((0, root));

        while (queue.Any())
        {
            var nvl = queue.Dequeue();
            if (!dictionary.ContainsKey(nvl.level)) dictionary[nvl.level] = new List<int>();

            ProceedNextNode(nvl.node.left);
            ProceedNextNode(nvl.node.right);

            dictionary[nvl.level].Add(nvl.node.val);

            void ProceedNextNode(TreeNode? node)
            {
                if (node == null)
                    return;

                queue.Enqueue((nvl.level + 1, node));
            }
        }

        for (int i = 0; i < dictionary.Count; i++)
        {
            if (i % 2 > 0)
                dictionary[i] = dictionary[i].Reverse().ToList();
        }

        return dictionary.Values.ToList();
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}