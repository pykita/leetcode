# Definition for singly-linked list.
class ListNode:
    def __init__(self, x, next_item = None):
        self.val = x
        self.next = next_item

def to_str(list_node: ListNode):
    while list_node.next:
        return to_str(list_node.next) + repr(list_node.val)
    else:
        return repr(list_node.val)

def to_list_node(number: int):
    ln_str = repr(number)
    current_node  = ListNode(int(ln_str[0]))
    next_node = None
    for digit in list(ln_str)[1:]:
        next_node = ListNode(int(digit))
        next_node.next = current_node
        current_node = next_node
    return current_node
    


class Solution:
    def addTwoNumbers(self, l1, l2):
        first_number = int(to_str(l1))
        second_number = int(to_str(l2))

        final_node = to_list_node(first_number + second_number)
        return final_node
        

def main():
    print(to_str(Solution().addTwoNumbers(ListNode(1, ListNode(8)), 
        ListNode(0))))

    # print(to_str(Solution().addTwoNumbers(ListNode(2, ListNode(4, ListNode(3))),
    #     ListNode(5, ListNode(6, ListNode(4))))))


if __name__ == '__main__':
    main()