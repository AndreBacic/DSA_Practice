/// <summary>
/// Definition for a binary tree node.
/// </summary>
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution {
    // Apparently properties are faster than fields? LeetCode runtimes for properties are 99-110ms, while fields are 143-147ms
    private int MaxDiameter { get; set; } = 0;
    /// <summary>
    /// Diameter of a binary tree is the length of the longest path between two nodes in a tree.
    /// O(n) time, O(n) space (recursion stack)
    /// </summary>
    public int DiameterOfBinaryTree(TreeNode root) {
        Dfs(root);
        return MaxDiameter;
    }
    private int Dfs(TreeNode root) {
        if (root is null) return 0;
        int ld = Dfs(root.left);
        int rd = Dfs(root.right);
        MaxDiameter = Math.Max(MaxDiameter, ld+rd);
        return 1+Math.Max(ld, rd);
    }
}