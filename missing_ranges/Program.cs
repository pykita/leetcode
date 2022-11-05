public class Solution
{
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
    {
        List<string> ans = new List<string>();

        for (int i = 0; i <= nums.Length; i++){

            long start = lower, end = upper;
            if (i != 0) start = nums[i-1] + 1;
            if (i != nums.Length) end = nums[i] - 1;

            // если на один болшьше предыдущего равен на один меньше текущего
            if (start == end) ans.Add(start.ToString());
            else if (start < end) ans.Add($"{start}->{end}");
        }
        return ans;
    }
}