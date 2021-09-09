from typing import List


# Definition for a Node.
class Node:
    def __init__(self, val=None, children=None):
        self.val = val
        self.children: List[Node] = children


class Solution:
    def preorder(self, root: 'Node') -> List[int]:
        if not root: return []

        output = []

        output.append(root.val)
        for c in root.children:
            output += self.preorder(c)

        return output