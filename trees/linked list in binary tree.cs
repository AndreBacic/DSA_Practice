/// Definition for singly-linked list.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

/// Definition for a binary tree node.
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
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        Stack<TreeNode> stack = new Stack<TreeNode>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            TreeNode node = stack.Pop();

            if (node.left != null)
            {
                stack.Push(node.left);
            }
            if (node.right != null)
            {
                stack.Push(node.right);
            }

            if (node.val == head.val)
            {
                bool isSubPath = IsSameTree(head, node);
                if (isSubPath)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool IsSameTree(ListNode head, TreeNode root)
    {
        if (head == null)
        {
            return true;
        }
        if (root == null)
        {
            return false;
        }
        if (root.val == head.val)
        {
            return IsSubPathFromRoot(head.next, root.left) || IsSubPathFromRoot(head.next, root.right);
        }
        return false;
    }
}