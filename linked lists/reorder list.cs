// Definition for singly-linked list.
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
public class Solution
{
    // O(n) time, O(n) space
    public void ReorderList(ListNode head)
    {
        List<ListNode> a = new();

        while (head is not null)
        {
            a.Add(head);
            head = head.next;
        }

        int l = 0, r = a.Count - 1, b = 1;
        while (l != r)
        {
            a[l].next = a[r];
            l += b; b = -b;
            (l, r) = (r, l);
        }
        a[l].next = null;
    }
}