var r = new Solution().Divide(2147483647, -2147483648);

Console.Write("");

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue)
        {
            if (divisor == -1)
                return int.MaxValue;
            if (divisor == 1)
                return int.MinValue;

            dividend = int.MinValue + 1;
        }

        if (divisor == int.MinValue)
        {
            if (dividend == int.MaxValue)
                return 0;

            divisor = int.MinValue + 1;
        }

        // build dictionary
        int absDividend = Math.Abs(dividend);
        int current = Math.Abs(divisor);
        var dictionary = new Dictionary<int, int>();
        var queue = new Queue<(int, int)>();
        queue.Enqueue((1, current));

        while (queue.Any())
        {
            (int quantity, current) = queue.Dequeue();
            dictionary[quantity] = current;

            if (current + current < 0)
                continue;

            if (current + current < absDividend)
                queue.Enqueue((quantity + quantity, current + current));
        }

        // find result
        var reverse = dictionary.Reverse();
        int tempSum = 0, res = 0, lastKey = 0;
        var enumerator = reverse.GetEnumerator();
        bool next = enumerator.MoveNext();

        while (next)
        {
            current = enumerator.Current.Value;

            if (tempSum + current < 0)
            {
                next = enumerator.MoveNext();
                continue;
            }

            if (tempSum + current > absDividend)
            {
                next = enumerator.MoveNext();
                continue;
            }

            tempSum += current;
            lastKey = enumerator.Current.Key;
            res += lastKey;
        }

        if (tempSum + current == int.MinValue && dividend < 0)
            res += lastKey;

        if (dividend < 0 && divisor < 0 || dividend > 0 && divisor > 0)
            return res;

        return -res;
    }
}