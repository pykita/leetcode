from collections import List

class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        next_idx = 0
        last_val = nums[0]
        
        for idx, val in enumerate(nums):
            if val != last_val:
                nums[next_idx] = last_val
                last_val = val
                next_idx += 1
            
            
        nums[next_idx] = last_val
        
        del nums[next_idx + 1:]

        return next_idx