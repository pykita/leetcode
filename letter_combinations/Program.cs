
Console.WriteLine("Hello, World!");

public class Solution {
    public IList<string> LetterCombinations(string digits)
    {
        var dic = new Dictionary<char, string[]>
        {
            { '1', Array.Empty<string>() },
            { '2', new[] { "a", "b", "c" } },
            { '3', new[] { "d", "e", "f" } },
            { '4', new[] { "g", "h", "i" } },
            { '5', new[] { "j", "k", "l" } },
            { '6', new[] { "m", "n", "o" } },
            { '7', new[] { "p", "q", "r", "s" } },
            { '8', new[] { "t", "u", "v" } },
            { '9', new[] { "w", "x", "y", "z" } },
            { '0', Array.Empty<string>() },
        };

        var digitsArr = new Queue<char>(digits.ToCharArray());

        return GetCombinations(digitsArr, dic).ToList()!;
    }

    private IEnumerable<string> GetCombinations(Queue<char> digits, Dictionary<char, string[]> dic)
    {
        if (!digits.Any())
            return Array.Empty<string>();

        var currentStrings = dic[digits.Dequeue()];
        var nextStrings = GetCombinations(digits, dic).ToArray();

        if (!nextStrings.Any())
            return currentStrings;

        if (!currentStrings.Any())
            return nextStrings;

        return (from c in currentStrings from nextChar in nextStrings select $"{c}{nextChar}").ToList();
    }
}