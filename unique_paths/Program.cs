public class Solution {
    public int UniquePaths(int m, int n)
    {
        int i = 0;
        SearchNext((1,1), (m, n), ref i);

        return i;
    }

    void SearchNext((int x, int y) currectCell, (int x, int y) destinationCell, ref int i)
    {
        if (currectCell.x < destinationCell.x)
        {
            SearchNext((currectCell.x + 1, currectCell.y), destinationCell, ref i);
        }

        if (currectCell.y < destinationCell.y)
        {
            SearchNext((currectCell.x, currectCell.y + 1), destinationCell, ref i);
        }

        if (currectCell == destinationCell)
        {
            i++;
        }
    }
}