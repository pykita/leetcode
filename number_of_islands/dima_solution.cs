public class Solution
{
    public int NumIslands(char[][] grid)
    {
        Dictionary<(int, int), char> slots = new Dictionary<(int, int), char>();

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '1')
                {
                    slots.Add((i, j), grid[i][j]);
                }
            }
        }

        int islandsCount = 0;

        while (slots.Count > 0)
        {
            var first = slots.Keys.First();

            DetermineIsland(first, new Stack<(int, int)>(), slots);

            islandsCount++;
        }

        return islandsCount;
    }

    void DetermineIsland(
        (int, int) parent,
        Stack<(int, int)> openSlots,
        Dictionary<(int, int), char> slots
    )
    {
        slots.Remove(parent);

        var neig = GetNeighbors(parent, slots).ToArray();

        if (neig.Any())
        {
            foreach (var n in neig)
            {
                slots.Remove(n);

                openSlots.Push(n);
            }
        }

        if (openSlots.Any())

            DetermineIsland(openSlots.Pop(), openSlots, slots);
    }

    IEnumerable<(int, int)> GetNeighbors((int, int) parent, Dictionary<(int, int), char> slots)
    {
        var nbrs = new List<(int, int)>();

        if (slots.ContainsKey((parent.Item1 + 1, parent.Item2)))
            nbrs.Add((parent.Item1 + 1, parent.Item2));

        if (slots.ContainsKey((parent.Item1 - 1, parent.Item2)))
            nbrs.Add((parent.Item1 - 1, parent.Item2));

        if (slots.ContainsKey((parent.Item1, parent.Item2 + 1)))
            nbrs.Add((parent.Item1, parent.Item2 + 1));

        if (slots.ContainsKey((parent.Item1, parent.Item2 - 1)))
            nbrs.Add((parent.Item1, parent.Item2 - 1));

        return nbrs;
    }
}
