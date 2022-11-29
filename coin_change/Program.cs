public class Solution {
    public int CoinChange(int[] coins, int amount) {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((amount, 0));

        while (queue.Any())
        {
            var current = queue.Dequeue();

            if (current.Item1 == 0)
                return current.Item2;

            if (current.Item1 < 0)
                continue;

            for (int j = 0; j < coins.Length; j++)
            {
                queue.Enqueue((current.Item1 - coins[j], current.Item2 + 1));
            }
        }

        return -1;
    }
}