new Solution().GenerateParenthesis(3);

public class Solution {
    public IList<string> GenerateParenthesis(int n)
    {
        var res = GenerateNext(n - 1, n, new List<string>() {"("});

        return res;
    }

    private List<string> GenerateNext(int toOpen, int toClose, List<string> baseList)
    {
        List<string> result = null;

        if (toOpen > 0)
        {
            var nextResult = new List<string>();
            for (int i = 0; i < baseList.Count; i++) nextResult.Add($"{baseList[i]}(");

            nextResult = GenerateNext(toOpen - 1, toClose, nextResult);
            result = nextResult;
        }

        if (toClose > 0 && toClose > toOpen )
        {
            var nextResult = new List<string>();
            for (int i = 0; i < baseList.Count; i++) nextResult.Add($"{baseList[i]})");

            nextResult = GenerateNext(toOpen, toClose - 1, nextResult);
            if (result == null)
                result = nextResult;
            else
                result.AddRange(nextResult);
        }

        if (result == null)
            return baseList;

        return result;
    }
}