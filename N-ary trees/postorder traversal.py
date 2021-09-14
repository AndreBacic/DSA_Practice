from preorder_traversal import Node
from typing import List

class Solution:
    def postorder(self, root: 'Node') -> List[int]:
        if not root: return []

        output = []

        for c in root.children:
            output += self.postorder(c)
        output.append(root.val)
        
        return output