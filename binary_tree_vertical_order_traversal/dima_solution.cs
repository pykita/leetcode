public class Solution {
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var set = new SortedSet<(int, SortedSet<(int, List<int>)>)>();
        
        AddNodes(set, root, 0, 0);

        var result = new List<IList<int>>();
        foreach (var tuple in set)
            result.Add(GetList(tuple.Item2));

        return result;
    }

    List<int> GetList(SortedSet<(int, List<int>)> set)
    {
        var result = new List<int>();
        foreach (var tuple in set)
        {
            tuple.Item2.Sort();
            result.AddRange(tuple.Item2);
        }
        
        return result;
    }

    void AddNodes(        
        SortedSet<(int, SortedSet<(int, List<int>)>)> set,
        TreeNode node,
        int columnIndex,
        int rawIndex)
    {
        var element = set.FirstOrDefault(a => a.Item1 == columnIndex, (Int32.MinValue, null));
        if (element.Item1 == Int32.MinValue)
        {
            var col = new SortedSet<(int, List<int>)> { (rawIndex, new List<int> { node.val }) };
            set.Add((columnIndex, col));
        }
        else
        {
            var element2 = element.Item2.FirstOrDefault(a => a.Item1 == rawIndex, (Int32.MinValue, null));
            if (element2.Item1 == Int32.MinValue)
                element.Item2.Add((rawIndex, new List<int> { node.val }));
            else
                element2.Item2.Add(node.val);
        }
        
        if (node.right != null)
            AddNodes(set, node.right, columnIndex + 1, rawIndex + 1);
        
        if (node.left != null)
            AddNodes(set, node.left, columnIndex - 1, rawIndex + 1);
    }
}