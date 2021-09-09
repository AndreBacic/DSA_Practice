from preorder_traversal import Node
from typing import List

class Solution:
    def maxDepth(self, root: 'Node') -> int:
        if not root: return 0
        self.max_depth = 1
        def bottom_up_rec(child: 'Node', cur_depth):
            if cur_depth > self.max_depth:
                self.max_depth = cur_depth
            for c in child.children:
                bottom_up_rec(c, cur_depth+1)
        
        bottom_up_rec(root, 1)
        return self.max_depth
        