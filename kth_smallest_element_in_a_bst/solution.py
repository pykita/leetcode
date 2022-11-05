from typing import Optional


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right
def find_lowest_kth(curr_node, prev_node):
    while curr_node.left:
        prev_node = curr_node
        curr_node = curr_node.left
        
    if not prev_node:
        return curr_node.val, curr_node.right
        
    if curr_node.right:
        prev_node.left = curr_node.right
    else:
        prev_node.left = None
        
    return curr_node.val, None

class Solution:
    def kthSmallest(self, root: Optional[TreeNode], k: int) -> int:
        val = None
        while k > 0:
            val, new_node = find_lowest_kth(root, None)
            root = new_node if new_node else root
            k -= 1
        return val
