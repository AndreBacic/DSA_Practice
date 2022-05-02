public class Trie {
    
    private TrieNode root; 

    public Trie() {
        root = new TrieNode("");
    }
    
    public void Insert(string word) {
        TrieNode n = root;
        int depth = 0;
        foreach (char l in word) {
            depth++;
            if (n.Children.ContainsKey(l)) {
                n = n.Children[l];
                continue;
            }
            var c = new TrieNode("");
            n.Children.Add(l, c);
            n = c;
        }
        n.val = word;
    }
    
    public bool Search(string word) {
        TrieNode n = root;
        foreach (char l in word) {
            if (n.Children.ContainsKey(l)) {
                n = n.Children[l];
                continue;
            }
            return false;
        }
        return n.val == word;
    }
    
    public bool StartsWith(string prefix) {
        TrieNode n = root;
        foreach (char l in prefix) {
            if (n.Children.ContainsKey(l)) {
                n = n.Children[l];
                continue;
            }
            return false;
        }
        return true;
    }
}
public class TrieNode {
    public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
    public string val;
    public TrieNode(string val) {
        this.val = val;
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */