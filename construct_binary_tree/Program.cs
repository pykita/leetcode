//new Solution().BuildTree(new[] { 3, 9, 20, 15, 7 }, new[] { 9, 3, 15, 20, 7 });
new Solution().BuildTree(new[] { -1 }, new[] { -1 });

public class Solution {
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        int Rec(int preorderIndex, Span<int> inorderInterval, TreeNode currentNode)
        {
            for (int i = 0; i < inorderInterval.Length; i++)
            {
                if (preorderIndex == preorder.Length)
                    break;

                if (preorder[preorderIndex] == inorderInterval[i])
                {
                    currentNode.val = preorder[preorderIndex];
                    preorderIndex++;

                    if (i > 0)
                    {
                        currentNode.left = new TreeNode();
                        preorderIndex = Rec(preorderIndex, inorderInterval.Slice(0, i), currentNode.left);
                    }

                    if (inorderInterval.Length - (i+1) > 0)
                    {
                        currentNode.right = new TreeNode();
                        preorderIndex = Rec(preorderIndex, inorderInterval.Slice((i+1), inorderInterval.Length - (i+1)), currentNode.right);
                    }
                }
            }

            return preorderIndex;
        }

        var root = new TreeNode();
        Rec(0, inorder.AsSpan(), root);

        return root;
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}