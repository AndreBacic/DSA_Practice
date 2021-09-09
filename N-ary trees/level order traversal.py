from preorder_traversal import Node
from typing import List

class Solution:
    def levelOrder(self, root: 'Node') -> List[List[int]]:
        if not root: return []

        output = [[root.val]]
        
        queue: List['Node'] = [root]
        step = 0
        while (len(queue) > 0):
            step += 1
            l = []
            size = len(queue)
            for i in range(size):
                current = queue.pop(0)
                for child in current.children:
                    l.append(child.val)
                    queue.append(child)
            if len(l) > 0: output.append(l)
                    
        return output

        