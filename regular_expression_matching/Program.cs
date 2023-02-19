using System.Linq.Expressions;
var res = new Solution().IsMatch("ab", ".*c");
Console.WriteLine("");

public class Solution {
    public bool IsMatch(string s, string p)
    {
        if (!p.Any()) return !s.Any();
        
        bool firstMatch = s.Any() && (p.ElementAt(0) == s.ElementAt(0) || p.ElementAt(0) == '.');

        if (p.Length >= 2 && p.ElementAt(1) == '*')
        {
            return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
        }

        return (firstMatch && IsMatch(s.Substring(1), p.Substring(1)));
    }
}