public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 0) return "";
        if (s.Length == 1) return s;
        if (s.Length == 2)
            return s[0] == s[1] ? s : s[0].ToString();

        var listOfPalindromes = new List<List<char>>();

        LongestPalindromeInternal(0, 1, false, s, listOfPalindromes);
        LongestPalindromeInternal(0, 2, true, s, listOfPalindromes);

        char[] re = listOfPalindromes.OrderBy(l => l.Count).ToArray().LastOrDefault()?.ToArray() ?? Array.Empty<char>();

        if (!re.Any())
            return s[1].ToString();

        return string.Join("", re);
    }

    private void LongestPalindromeInternal(int indexC1, int indexC2, bool middleChar, string word,
        List<List<char>> listOfPalindromes)
    {
        var li = new List<char>();

        while (true)
        {
            if (indexC2 == word.Length)
                break;

            int index1 = indexC1;
            int index2 = indexC2;

            while (index2 < word.Length && index1 >= 0)
            {
                if (word[index1] != word[index2])
                    break;

                li.Insert(0, word[index1]);
                if (middleChar && li.Count == 1)
                    li.Add(word[index1 + 1]);
                li.Add(word[index2]);

                index1--;
                index2++;
            }

            if (li.Any())
            {
                listOfPalindromes.Add(li);
                li = new List<char>();
            }

            indexC1++;
            indexC2++;
        }
    }
}