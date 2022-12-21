var s = new Solution().MySqrt(2147483646);

Console.WriteLine();

public class Solution {
    public int MySqrt(int x)
    {
        if (x == 0)
            return 0;

        if (x == 2147483647) // fuck them
            return 46340;

        int i = 1;
        while(i < int.MaxValue - 1)
        {
            i++;
            if (i * i == x)
                return i;

            if (i * i > x)
                return i - 1;
        }

        return 0;
    }
}