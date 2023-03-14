public class Trie
{
    private HashSet<string> _words;
    private Node _root;
    
    public Trie() {
        _root = new Node { Key = ' ', Childs = new List<Node>() };
        _words = new HashSet<string>();
    }
    
    public void Insert(string word)
    {
        _words.Add(word);

        var current = _root;
        foreach (var letter in word) {
            for (int i = 0; i < current.Childs.Count; i++) {
                if (current.Childs[i].Key == letter) {
                    current = current.Childs[i];
                    goto gonext;
                }
            }

            var newNode = new Node { Key = letter, Childs = new List<Node>() };
            current.Childs.Add(newNode);
            current = newNode;
            
            gonext: ;
        }
        
        current.Childs.Add(new Node() { Key = Char.MaxValue });
    }
    
    public bool Search(string word) {
        return _words.Contains(word);
    }
    
    public bool StartsWith(string prefix) {
        var current = _root;
        
        foreach (var letter in prefix) {
            
            for (int i = 0; i < current.Childs.Count; i++) {
                if (current.Childs[i].Key == letter) {
                    current = current.Childs[i];
                    goto gonext;
                }
            }

            return false;
            
            gonext: ;
        }

        return true;
    }

    private record Node
    {
        public char Key { get; set; }
        public IList<Node> Childs { get; set; }
    }
}