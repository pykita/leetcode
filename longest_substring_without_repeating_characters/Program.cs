public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        var q = new Queue<char>();
        var uniqueSequences = new List<int>();

        foreach (var c in s)
        {
            if (q.Contains(c))
            {
                uniqueSequences.Add(q.Count);
                while (q.TryDequeue(out char ch) && ch != c) { }
            }

            q.Enqueue(c);
        }

        uniqueSequences.Add(q.Count);

        return uniqueSequences.Max();
    }
}
