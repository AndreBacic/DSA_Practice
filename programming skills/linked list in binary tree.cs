/// Definition for singly-linked list.
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

/// Definition for a binary tree node.
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

public class TreeLinkPair {
    public TreeNode node;
    public ListNode list;
    public TreeLinkPair(TreeNode node, ListNode list) {
        this.node = node;
        this.list = list;
    }
}

public class Solution {
    public bool IsSubPath(ListNode head, TreeNode root) {
        Stack<TreeLinkPair> stack = new Stack<TreeLinkPair>();

        stack.Push(new TreeLinkPair(root, head));

        while (stack.Count > 0) {
            TreeLinkPair pair = stack.Pop();

            if (pair.node == null) {
                continue;
            }
            
            stack.Push(new TreeLinkPair(pair.node.left, head));
            stack.Push(new TreeLinkPair(pair.node.right, head));

            if (pair.node.val == pair.list.val) {
                if (pair.list.next == null) {
                    return true;
                }
                stack.Push(new TreeLinkPair(pair.node.left, pair.list.next));
                stack.Push(new TreeLinkPair(pair.node.right, pair.list.next));
            }
        }
        return false;
    }
}