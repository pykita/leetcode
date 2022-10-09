from typing import List
class NestedInteger:
   def __init__(self, value=None):
       """
       If value is not specified, initializes an empty list.
       Otherwise initializes a single integer equal to value.
       """

   def isInteger(self):
       """
       @return True if this NestedInteger holds a single integer, rather than a nested list.
       :rtype bool
       """

   def add(self, elem):
       """
       Set this NestedInteger to hold a nested list and adds a nested integer elem to it.
       :rtype void
       """

   def setInteger(self, value):
       """
       Set this NestedInteger to hold a single integer equal to value.
       :rtype void
       """

   def getInteger(self):
       """
       @return the single integer that this NestedInteger holds, if it holds a single integer
       Return None if this NestedInteger holds a nested list
       :rtype int
       """

   def getList(self):
       """
       @return the nested list that this NestedInteger holds, if it holds a nested list
       Return None if this NestedInteger holds a single integer
       :rtype List[NestedInteger]
       """

def get_max_depth(nested_list: List[NestedInteger]) -> int:
    def dfs(parent_node, depth) -> int:
        max_depth = depth
        for curr_node in parent_node:
            if not curr_node.isInteger() and curr_node.getList():
                max_depth = max(max_depth, dfs(curr_node.getList(), depth + 1))

        return max_depth

    return dfs(nested_list, 1)

def get_dfs_sum(parent_node, curr_depth: int, max_depth) -> int:
    total_sum = 0
    for curr_node in parent_node:
        if not curr_node.isInteger():
            total_sum += get_dfs_sum(curr_node.getList(), curr_depth + 1, max_depth)
        else:
            weight = max_depth - curr_depth + 1
            print(f'The current weight is {weight}')
            total_sum += curr_node.getInteger() * weight

    return total_sum

class Solution:
    def depthSumInverse(self, nestedList: List[NestedInteger]) -> int:
        max_depth = get_max_depth(nestedList)
        print(f'Max depth is:{max_depth}')

        return get_dfs_sum(nestedList, 1 ,max_depth)

        