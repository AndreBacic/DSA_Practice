public class Trie {
    
    private TrieNode root; 

    /// <summary>
    /// Initializes an empty symbol table.
    /// O(1) time and space.
    /// </summary>
    public Trie() {
        root = new TrieNode("");
    }
    
    /// <summary>
    /// Adds the word to the symbol table.
    /// O(n) time
    /// O(1) space best case (last letter is the only new letter)
    /// O(n) space worst case (all letters are new)
    /// </summary>
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
    
    /// <summary>
    /// Returns true if the word is in the symbol table.
    /// Note that if word is a prefix of some other word in the symbol table, false will be returned.
    /// O(n) time worst case (word is in the trie)
    /// O(1) time best case (first letter isn't in the trie's root's children)
    /// O(1) space
    /// </summary>
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
    
    /// <summary>
    /// Returns true if there is any word in the symbol table that starts with the given prefix.
    /// O(n) time worst case (prefix is in the trie)
    /// O(1) time best case (prefix isn't in the trie's root's children)
    /// O(1) space
    /// </summary>
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