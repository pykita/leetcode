using System.Text;

Console.WriteLine(new Solution().LargestNumber(new []{9,30,34,5,3}));

public class Solution {
    public string LargestNumber(int[] nums)
    {
        if (nums[0] == 0 && nums.Sum() == 0)
            return "0";

        List<IntContainer> ic = new List<IntContainer>();

        foreach (var num in nums)
            ic.Add(new IntContainer(num));

        ic.Sort();

        var sb = new StringBuilder(ic.Count);
        for (int i = ic.Count - 1; i >= 0; i--)
            sb.Append(ic[i]);

        return sb.ToString();;
    }

    private class IntContainer : IComparable<IntContainer>
    {
        private int _value;

        public IntContainer(int value) => _value = value;

        public override string ToString() => _value.ToString();

        public int CompareTo(IntContainer? other)
        {
            var thisFirst = Combine(_value, other._value);
            var thisSecond = Combine(other._value, _value);

            if (thisFirst == thisSecond)
                return 0;

            return thisFirst > thisSecond ? 1 : -1;
        }

        ulong Combine(int value1, int value2)
        {
            return ulong.Parse($"{value1}{value2}");
        }
    }
}