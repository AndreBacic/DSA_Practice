// Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    /// <summary>
    /// O(r*s) time, O(r*s) space, where r and s are the number of nodes in the tree and subtree, respectively.
    /// </summary>
    public bool IsSubtree(TreeNode root, TreeNode subRoot)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();

            if (node.left != null) stack.Push(node.left);
            if (node.right != null) stack.Push(node.right);

            if (node.val == subRoot.val)
            {
                bool isSubPath = IsSameTree(subRoot, node);
                if (isSubPath) return true;
            }
        }
        return false;
    }
    public bool IsSameTree(TreeNode subRoot, TreeNode node)
    {
        if (subRoot is null)
        {
            if (node is null) return true;
            return false;
        }
        if (node is null) return false;
        if (subRoot.val == node.val) return IsSameTree(subRoot.left, node.left) && IsSameTree(subRoot.right, node.right);
        return false;
    }
}
