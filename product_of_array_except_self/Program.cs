var r = new Solution().ProductExceptSelf(new[] { 2, 6, 7 });

public class Solution {
    public int[] ProductExceptSelf(int[] nums)
    {
        var cache = new (int forward, int backward)[nums.Length];

        int temp = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            temp *= nums[i];
            cache[i] = (forward: temp, backward: 0);
        }

        temp = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            temp *= nums[i];
            cache[i] = (cache[i].forward, backward: temp);
        }

        var result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && i < nums.Length - 1)
                result[i] = (cache[i - 1].forward * cache[i + 1].backward);
            else if (i == 0)
                result[0] = cache[1].backward;
            else
                result[i] = cache[i - 1].forward;
        }

        return result;
    }
}