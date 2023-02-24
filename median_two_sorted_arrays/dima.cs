using System.Linq.Expressions;

var s = new Solution().FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3, 4 });
//var s = new Solution().FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 });

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var res = new int[nums1.Length + nums2.Length];
        int i1, i2, r;
        for (i1 = nums1.Length - 1, i2 = nums2.Length - 1, r = res.Length - 1; i1 >= 0 && i2 >= 0;)
        {
            res[r--] = nums1[i1] <= nums2[i2] ? nums2[i2--] : nums1[i1--];
        }

        var (remain, index) = i1 > i2 ? (nums1, i1) : (nums2, i2);
        
        for (; index >= 0; index--)
        {
            res[r--] = remain[index];
        }

        if ((res.Length & 1) == 1)
        {
            return  res[res.Length / 2];
        }
        
        return ((double)res[res.Length / 2 - 1] + (double)res[res.Length / 2]) / 2;
    }
}