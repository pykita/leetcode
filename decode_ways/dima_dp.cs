public class Solution
{
    public int NumDecodings(string s)
    {
        if (s[0] == '0')
            return 0;

        if (s.Length == 1)
            return 1;

        var dp = new int[s.Length];
        Array.Fill(dp, -1);

        int next = 0;
        if (IsLetter(s.Length - 1))
            dp[s.Length - 2] = 1;
        else
            dp[s.Length - 2] = 0;
        dp[s.Length - 1] = 1;

        for (int j = s.Length - 1, x = s.Length - 2, n = s.Length - 3; x >= 0; j--, x--, n--)
        {
            if (!IsLetter(x))
            {
                dp[n] = 0;
                continue;
            }

            next = 0;
            if (IsLetter(x))
                next = dp[x];

            if (IsLetter2(x, j))
                next = dp[x] + dp[j];

            if (n >= 0)
                dp[n] = next;
        }

        return next;

        bool IsLetter2(int start, int end)
        {
            if (int.Parse(s.Substring(start, end - start + 1)) > 26)
                return false;

            return true;
        }

        bool IsLetter(int start)
        {
            if (s[start] == '0')
                return false;

            if (int.Parse(s.Substring(start, 1)) > 26)
                return false;

            return true;
        }
    }
}