public class Solution
{
    public void SetZeroes(int[][] matrix)
    {
        Span<(int, int)> span = stackalloc (int x, int y)[1024];
        int index = 0;
        
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    span[index] = (i, j);
                    index++;
                }
            }
        }

        for (int i = 0; i < index; i++)
        {
            var (x, y) = span[i];

            for (int l = 0; l < matrix[x].Length; l++)
            {
                matrix[x][l] = 0;
            }

            for (int n = 0; n < matrix.Length; n++)
            {
                matrix[n][y] = 0;
            }
        }
    }
}