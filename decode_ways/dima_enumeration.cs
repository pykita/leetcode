var t1 = new Solution().NumDecodings("10221320");
var t3 = new Solution().NumDecodings("22");
var t5 = new Solution().NumDecodings("10");

Console.WriteLine();

public class Solution {
    public int NumDecodings(string s)
    {
        if (s[0] == '0')
            return 0;

        int i = 0;

        TryDecode(0);

        void TryDecode(int start)
        {
            if (start >= s.Length)
                i++;

            for (int end = start; end < s.Length; end++)
            {
                if (!IsLetter(start, end))
                    continue;

                TryDecode(end + 1);
            }
        }

        return i;

        bool IsLetter(int start, int end)
        {
            if (end - start >= 2)
                return false;

            if (int.Parse(s.Substring(start, end - start + 1)) > 26)
                return false;

            if (end < s.Length - 1 && s[end + 1] == '0')
                return false;

            return true;
        }
    }
}
