# Definition for singly-linked list.
from typing import Optional

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next
class Solution:
    def oddEvenList(self, head: Optional[ListNode]) -> Optional[ListNode]:
        last_odd, last_even, first_even, first_odd = None, None, None, None
        curr = head
        index = 0
        
        while curr:
            # print(f'Current node: {curr}')
            if index % 2 != 0:
                if first_even:
                    last_even.next = curr
                    last_even = curr
                else:
                    first_even = curr
                    last_even = curr
                    
            else:
                if first_odd:
                    last_odd.next = curr
                    last_odd = curr
                else:
                    first_odd = curr
                    last_odd = curr
        
            curr = curr.next
            index += 1
            
        if first_odd and first_even:
            last_even.next = None
            last_odd.next = first_even
            head = first_odd
        
        return head