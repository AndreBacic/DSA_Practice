# Definition for a binary tree node.
from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        self.good_balance = True
        self.depth(root)
        return self.good_balance
    
    def depth(self, root: Optional[TreeNode]) -> int:
        if root is None:
            return 0
        
        dl = self.depth(root.left)
        dr = self.depth(root.right)
        if abs(dl - dr) > 1:
            self.good_balance = False
        
        return max(dl, dr) + 1