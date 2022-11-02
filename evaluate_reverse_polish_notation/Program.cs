using System.Text.RegularExpressions;

public class Solution {
    public int EvalRPN(string[] tokens)
    {
        var list = tokens.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            if (Regex.IsMatch(list[i], @"^[\/\+\-\*]$"))
            {
                var t = CalculateExpression(list[i - 2], list[i - 1], list[i]).ToString();
                list.RemoveRange(i-2, 3);
                list.InsertRange(i-2, new []{t});
                i = 0;
            }
        }

        return Int32.Parse(list.First());
    }

    int CalculateExpression(string a, string b, string operation)
    {
        int ai = Int32.Parse(a), bi = Int32.Parse(b);
        int result = operation switch
        {
            "+" => ai + bi,
            "-" => ai - bi,
            "*" => ai * bi,
            "/" => ai / bi
        };

        return result;
    }
}