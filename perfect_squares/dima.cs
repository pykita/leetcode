//var r = new Solution().NumSquares(8285);
var r = new Solution().NumSquares(12);

Console.WriteLine();

public class Solution
{
    private int[] _dp;

    public int NumSquares(int n)
    {
        _dp = new int[n + 1];
        Array.Fill(_dp, -1);
        var res = GetMinimumSquaresFor(n, n);
        return res;
    }

    int GetMinimumSquaresFor(int index, int value)
    {
        if (_dp[index] != -1)
            return _dp[index];

        int result = int.MaxValue;

        if (index < 1)
        {
            _dp[index] = 0;
            return 0;
        }
        
        for (int current = index; current >= 1; current--)
        {
            if (IsPerfectSquare(current))
            {
                result = Math.Min(GetMinimumSquaresFor(value - current, value - current) + 1, result);
            }
        }

        _dp[index] = result;
        
        return result;
    }

    bool IsPerfectSquare(int value) => Math.Sqrt(value) % 1 == 0;
}