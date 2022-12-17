var result = new Solution().Permute(new[] { 1, 2, 3 });

Console.WriteLine();

public class Solution {
    public IList<IList<int>> Permute(int[] nums)
    {
        var resultList = new List<IList<int>>();
        var queue = new Queue<(Stack<int> processed, Stack<int> remain)>();
        queue.Enqueue((new Stack<int>(), new Stack<int>(nums)));

        while (queue.Any())
        {
            var (processed, remain) = queue.Dequeue();

            if (!remain.Any())
            {
                resultList.Add(processed.ToList());
            }
            else
            {
                foreach (var value in remain)
                {
                    var newProcessed = new Stack<int>(processed);
                    var newRemain = new Stack<int>(remain.Except(new []{value}));
                    newProcessed.Push(value);
                    queue.Enqueue((newProcessed, newRemain));
                }
            }
        }

        return resultList.ToList();
    }
}