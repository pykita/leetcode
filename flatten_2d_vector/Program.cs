public class Vector2D
{
    private readonly Queue<int> _queue;

    public Vector2D(int[][] vec)
    {
        var a = (from arr in vec
            from i in arr
            select i).ToArray();

        _queue = new Queue<int>(a);
    }

    public int Next() => _queue.Dequeue();

    public bool HasNext() => _queue.TryPeek(out int i);
}