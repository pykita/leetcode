using static System.Math;

public class Solution
{
    private List<int> _history = new ();

    public bool IsHappy(int n)
    {
        int res = n;
        while (res != 1)
        {
            var l = NumberToListDigits(res);
            res = SumOfSquaresOfListDigits(l);

            if (res < 0 || _history.Contains(res))
                return false;

            _history.Add(res);
        }

        return true;
    }

    private IEnumerable<int> NumberToListDigits(int number)
    {
        return number.ToString()
            .Select(digit => int.Parse(digit.ToString()));
    }

    private int SumOfSquaresOfListDigits(IEnumerable<int> digits)
    {
        unchecked
        {
            int result = 0;
            digits.ToList().ForEach(d =>
            {
                result += (int)Pow(d, 2);
            });

            return result;
        }
    }
}