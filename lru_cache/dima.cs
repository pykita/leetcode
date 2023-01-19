public class LRUCache
{
    private int _maxCapacity, _currenctCapacity;
    private readonly Dictionary<int, LinkedNode> _dictionary;
    private LinkedNode? _lastNode;
    private LinkedNode? _firstNode;

    public LRUCache(int capacity)
    {
        _maxCapacity = capacity;
        _currenctCapacity = 0;
        _dictionary = new Dictionary<int, LinkedNode>();
    }
    
    public int Get(int key) 
    {
        if (_dictionary.ContainsKey(key))
        {
            var node = _dictionary[key];

            if (node == _firstNode)
                return _firstNode.value;

            RemoveNodeFromLinkedList(node);
            SetFirstNode(node);

            return _firstNode.value;
        }

        return -1;
    }
    
    public void Put(int key, int value)
    {
        LinkedNode? node = default;

        if (_dictionary.ContainsKey(key))
        {
            node = _dictionary[key];
            node.value = value;
            
            if (node == _firstNode)
                return;

            RemoveNodeFromLinkedList(node);
            SetFirstNode(node);
        }
        else
        {
            ++_currenctCapacity;
            node = new LinkedNode { value = value, key = key};
            _dictionary.Add(key, node);

            if (_lastNode == null)
                _lastNode = node;
            
            SetFirstNode(node);
            RemoveLastNodeIfNeeded();
        }
    }

    private void RemoveNodeFromLinkedList(LinkedNode node)
    {
        if (node.previous != null)
        {
            node.previous.next = node.next;
            if (node.next != null)
            {
                node.next.previous = node.previous;
            }
        }
        else
        {
            if (node.next != null)
            {
                node.next.previous = null;
                _lastNode = node.next;
            }
        }
    }

    private void SetFirstNode(LinkedNode node)
    {
        if (_firstNode == null)
        {
            _firstNode = node;
            return;
        }
        
        node.previous = _firstNode;
        _firstNode.next = node;
        _firstNode = node;
    }

    private void RemoveLastNodeIfNeeded()
    {
        if (_currenctCapacity <= _maxCapacity)
            return; 
        
        _dictionary.Remove(_lastNode.key);
        
        if (_lastNode.next != null) 
            _lastNode.next.previous = null;
        _lastNode = _lastNode.next;
        --_currenctCapacity;
    }
    
    private class LinkedNode
    {
        public int value;
        public int key;
        public LinkedNode? next;
        public LinkedNode? previous;
    }
}