using System.Collections;

var result = new Solution().Merge(new int[2][]
{
    new[] { 1, 3 },
    new[] { 0, 0 }
});

Console.Write(1);

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 1)
            return intervals;

        intervals = intervals.OrderBy(i => i[0]).ToArray();

        int index = 0;
        var currentInterval = intervals[index];
        var resultList = new List<int[]>(intervals.Length);

        for (index = 1; index < intervals.Length; index++)
        {
            var res = MergeIfNeeded(currentInterval, intervals[index]);

            if (res.Item1 != res.Item2)
                resultList.Add(res.Item1);

            if (index == intervals.Length - 1)
                resultList.Add(res.Item2);

            currentInterval = res.Item2;
        }

        (int[], int[]) MergeIfNeeded(int[] interval1, int[] interval2)
        {
            if (interval1[1] >= interval2[0])
            {
                interval2[0] = Math.Min(interval1[0], interval2[0]);
                interval2[1] = Math.Max(interval1[1], interval2[1]);

                return (interval2, interval2);
            }

            return (interval1, interval2);
        }

        return resultList.ToArray();
    }
}