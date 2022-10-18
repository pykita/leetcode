public class Solution {
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0) return new [] { -1, -1 };

        int result = Array.BinarySearch(nums, target);
        if (result < 0)
            return new [] { -1, -1 };

        int left = result, right = result;

        while (left - 1 >= 0 && nums[left - 1] == nums[result]) left--;

        while (right + 1 <= nums.Length - 1 && nums[right + 1] == nums[result]) right++;

        return new [] { left, right };
    }
}