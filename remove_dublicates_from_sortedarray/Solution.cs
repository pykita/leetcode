public class Solution {
    public int RemoveDuplicates(int[] nums)
    {
       var result = nums.Distinct().ToArray();
       for (int i = 0; i < result.Length; i++) nums[i] = result[i];

       return result.Length;
    }
}
