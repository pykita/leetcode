var r = new Solution().MyPow(3, -2);

Console.WriteLine(r);

public class Solution {
    public double MyPow(double x, int n)
    {
        var result = 1.0d ;
        for (int i = 0; i < Math.Abs(n); i++)
            result *= x;

        if (n < 0)
        {
            result = 1 / result;
        }

        return result;
    }
}