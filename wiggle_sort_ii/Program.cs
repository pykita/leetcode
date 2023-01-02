//var arr = new int[] { 2,1 };
new Solution().WiggleSort(arr);

Console.WriteLine();

public class Solution
{
    public void WiggleSort(int[] nums)
    {
        Array.Sort(nums);
        if (nums.Length < 3)
            return;

        Span<int> numbers = stackalloc int[nums.Length];
        var endIndex = nums.Length - 1;
        var midIndex = (nums.Length - 1) / 2;

        for (int i = 0; i < numbers.Length; i++)
        {
            if ((i & 1) == 0)
                numbers[i] = nums[midIndex--];
            else
                numbers[i] = nums[endIndex--];
        }

        for (int i = 0; i < numbers.Length; i++)
            nums[i] = numbers[i];
    }
}