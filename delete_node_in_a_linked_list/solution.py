# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def deleteNode(self, node):
        curr_node = node
        prev_node = None
        
        while curr_node.next:
            curr_node.val = curr_node.next.val
            prev_node = curr_node
            curr_node = curr_node.next
            
        
        prev_node.next = None
        
