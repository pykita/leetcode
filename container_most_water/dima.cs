public class Solution2 {
    public int MaxArea(int[] height)
    {
        int maxKnownArea = 0;

        for (int start = 0, end = height.Length - 1; start < end;)
        {
            maxKnownArea = Math.Max(maxKnownArea, GetArea(start, end));
            
            if (height[start] <= height[end])
                start++;
            else
                end--;
        }
        
        int GetArea(int index1, int index2) => Math.Min(height[index1], height[index2]) * (index2 - index1);

        return maxKnownArea;
    }
}