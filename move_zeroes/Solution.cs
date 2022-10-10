public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        var notZeroInts = new List<int>(nums)
            .FindAll(i => i != 0)
            .ToArray();

        for (int i = 0; i < nums.Length; i++) 
            nums[i] = i < notZeroInts.Length ? notZeroInts[i] : 0;
    }
}