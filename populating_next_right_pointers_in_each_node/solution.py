from typing import Optional

# Definition for a Node.
class Node:
    def __init__(self, val: int = 0, left: 'Node' = None, right: 'Node' = None, next: 'Node' = None):
        self.val = val
        self.left = left
        self.right = right
        self.next = next


class Solution:
    def connect(self, root: Optional[Node]) -> Optional[Node]:
        level_dict = {}
        if not root:
            return root
        queue = [(root, 1)]
        
        while queue:
            node, level = queue.pop(0)
            if level in level_dict:
                level_dict[level].next = node
                level_dict[level] = node
            else:
                level_dict[level] = node
                
            if node.left:
                queue.append((node.left, level + 1))
                
            if node.right:
                queue.append((node.right, level + 1))
                
        return root
