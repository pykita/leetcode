// Dmitry

var r = new Solution().Partition("ssssssssssssss");
Console.WriteLine();

public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        var memo = new Dictionary<string, List<IList<string>>>();
        var result = ExtractPalindromes(s, memo);
        return result;
    }

    private List<IList<string>> ExtractPalindromes(string word, Dictionary<string, List<IList<string>>> memo)
    {
        var result = new List<IList<string>>();

        if (memo.ContainsKey(word))
            return memo[word];

        if (IsPalindrome(word))
            result.Add(new List<string>(new[] { word }));

        for (int i = 1; i < word.Length; i++)
        {
            var firstHalf = ExtractPalindromes(word.Substring(0, i), memo);
            var secondHalf = ExtractPalindromes(word.Substring(i, word.Length - i), memo);

            foreach (var e1 in firstHalf)
            {
                foreach (var e2 in secondHalf)
                {
                    var cnct = e1.Concat(e2).ToList();
                    if (!ContainElement(result, cnct))
                        result.Add(cnct);
                }
            }

            bool ContainElement(List<IList<string>> source, IList<string> element)
            {
                foreach (var sEl in source)
                {
                    if (sEl.SequenceEqual(element))
                        return true;
                }

                return false;
            }
        }

        memo[word] = result;
        return result;
    }

    private bool IsPalindrome(string str)
    {
        int startIndex = 0, endIndex = str.Length - 1;
        while (startIndex <= endIndex)
        {
            if (str[startIndex] != str[endIndex])
                return false;

            startIndex++;
            endIndex--;
        }

        return true;
    }
}