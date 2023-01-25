var r = new Solution().SpiralOrder(new int[3][]
{
    new []{ 1, 2, 3, 7 },
    new []{ 4, 5, 6, 7 },
    new []{ 7, 8, 9, 7 },
});

Console.WriteLine(r);

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int nodesCount = matrix.Length * matrix[0].Length;
        var result = new List<int>(nodesCount);

        void Proceed1Dimension(int start, int end, int row, bool isReverse)
        {
            if (isReverse)
            {
                for (int i = end; i >= start; i--) AddElementToResult(matrix[row][i]);
            }
            else
            {
                for (int i = start; i <= end; i++) AddElementToResult(matrix[row][i]);
            }
        }

        void Proceed2Dimension(int start, int end, int row, bool isReverse)
        {
            if (isReverse)
            {
                for (int i = end; i >= start; i--) AddElementToResult(matrix[i][row]);
            }
            else
            {
                for (int i = start; i <= end; i++) AddElementToResult(matrix[i][row]);
            }
        }

        void AddElementToResult(int value)
        {
            if (result.Count < nodesCount) result.Add(value);
        }

        int NStart = 0, NEnd = matrix[0].Length - 1;
        int MStart = 0, MEnd = matrix.Length - 1;

        while (result.Count < nodesCount)
        {
            Proceed1Dimension(NStart, NEnd, MStart, false);
            MStart++;
            Proceed2Dimension(MStart, MEnd, NEnd, false);
            NEnd--;
            Proceed1Dimension(NStart, NEnd, MEnd, true);
            MEnd--;
            Proceed2Dimension(MStart, MEnd, NStart, true);
            NStart++;
        }

        return result;
    }
}