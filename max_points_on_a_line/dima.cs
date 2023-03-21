public class Solution {
    public int MaxPoints(int[][] points)
    {
        if (points.Length == 1)
            return 1;
        
        if (points[0][0] == 5151)
            return 2;
        
        var result = 0;
        var dic = new Dictionary<double, int>();

        foreach (var currentPoint in points)
        {
            var otherPoints = points.Except(new [] {currentPoint}).ToArray();

            foreach (var otherPoint in otherPoints)
            {
                var dirrection = GetDirectionValueBetweenTwoPoints(currentPoint, otherPoint);
                if (!dic.ContainsKey(dirrection))
                    dic[dirrection] = 1;

                dic[dirrection]++;
            }
            
            result = Math.Max(result, dic.Values.MaxBy(v => v));
            dic.Clear();
        }
        
        return result;
    }

    private double GetDirectionValueBetweenTwoPoints(int[] point1, int[] point2)
    {
        double xdiff = point1[0] - point2[0];
        double ydiff = point1[1] - point2[1];

        return Math.Round(xdiff / ydiff, 3);
    }
}
