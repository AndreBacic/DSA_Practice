from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def hasCycle(self, head: Optional[ListNode]) -> bool:
        """
        Determines if a singly-linked list contains a cycle.
        Uses the fast and slow pointers technique.

        O(n) time, O(1) space.
        """
        if not head: return False
        p1 = head
        p2 = head
        while p2.next and p2.next.next:
            p1 = p1.next
            p2 = p2.next.next
            if p1 is p2: return True
        
        return False