// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution {
    public Node CloneGraph(Node node) {
        if (node == null) return null; // empty graph edge case
        
        // O(n+m) time, O(n) space, where n is the number if nodes and m is the number of edges
        
        Node clone1 = new(node.val);
        
        Dictionary<int, Node> clones = new(); // each Node has a unique val that can be used as a key
        clones.Add(clone1.val, clone1);
        
        Queue<Node> q = new(); // queue of original nodes (I think a stack would work just as well)
        q.Enqueue(node);
        
        while (q.Count > 0) {
            Node orig = q.Dequeue();
            Node clone = clones[orig.val];
            foreach (Node n in orig.neighbors) {
                if (clones.ContainsKey(n.val)) { // already cloned n, so just link to it.
                    clone.neighbors.Add(clones[n.val]);
                }
                else {
                    Node c = new(n.val);
                    clones.Add(c.val, c);
                    clone.neighbors.Add(c);
                    q.Enqueue(n);
                }
            }
        }
        
        return clone1;
    }
}
