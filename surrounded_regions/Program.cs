// Dmitry

public class Solution
{
    public void Solve(char[][] board)
    {
        var surroundedRegions = new HashSet<int>();

        for (int i = 0; i < board.Length; i++) ExtractRegion(i, 0);

        for (int i = 0; i < board.Length; i++) ExtractRegion(i, board[i].Length - 1);

        for (int i = 0; i < board[0].Length; i++) ExtractRegion(0, i);

        for (int i = 0; i < board[^1].Length; i++) ExtractRegion(board.Length - 1, i);

        void ExtractRegion(int x, int y)
        {
            if (x >= 0 && x < board.Length
                       && y >= 0 && y < board[x].Length)
            {
                if (!surroundedRegions.Contains(CantorPair(x, y)))
                {
                    if (board[x][y] == 'O')
                    {
                        surroundedRegions.Add(CantorPair(x, y));
                        ExtractRegion(x + 1, y);
                        ExtractRegion(x - 1, y);
                        ExtractRegion(x, y + 1);
                        ExtractRegion(x, y - 1);
                    }
                }
            }
        }

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == 'O' && !surroundedRegions.Contains(CantorPair(i, j)))
                {
                    board[i][j] = 'X';
                }
            }
        }
    }

    static int CantorPair(int x, int y) {  // copy pasted from internet
        return (x + y) * (x + y + 1) / 2 + y;
    }
}