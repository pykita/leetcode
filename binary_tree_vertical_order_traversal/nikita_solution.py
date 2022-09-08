# Definition for a binary tree node.
from typing import List, Optional

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    min_index, max_index = 0,0
    def verticalOrder(self, root: Optional[TreeNode]) -> List[List[int]]:
        if not root:
            return []
        
        columns = {}
        output = []
        queue = [(root, 0)]
        
        while queue:
            current_node, current_index = queue.pop(0)
            
            if current_index in columns:
                columns[current_index].append(current_node.val)
            else:
                columns[current_index] = [current_node.val]
                
            self.min_index = min(self.min_index, current_index)
            self.max_index = max(self.max_index, current_index)
                
            if current_node.left:
                queue.append((current_node.left, current_index - 1))
                
            if current_node.right:
                queue.append((current_node.right, current_index + 1))
            
        for index in range(self.min_index, self.max_index + 1):
            output.append(columns[index])
            
        return output