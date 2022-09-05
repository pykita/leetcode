from typing import List

from sys import setrecursionlimit

class Solution:
    def canJump(self, nums: List[int]) -> bool:
        unreachable_set = set()
        
        def reach(idx: int) -> bool:
            if idx + 1 + nums[idx] >= len(nums):
                return True
            
            next_idx = idx + 1
            while next_idx < len(nums) and next_idx - idx <= nums[idx]:
                if next_idx not in unreachable_set:
                    unreachable_set.add(idx)
                    is_reached = reach(next_idx)
                    
                    if is_reached:
                        return True
                next_idx += 1
                
                
                    
            return False
        
        return reach(0)

    def can_jump_queue(self, nums: List[int]) -> bool:
        unreachable_set = set()
        unreachable_set.add(0)
        queue = [0]
        
        while queue:
            curr_idx = queue.pop(0)
            if curr_idx + 1 + nums[curr_idx] >= len(nums):
                print(curr_idx, len(nums))
                return True
            
            next_idx = curr_idx + 1
            while next_idx < len(nums):
                if next_idx not in unreachable_set and next_idx - curr_idx <= nums[curr_idx]:
                    unreachable_set.add(next_idx)
                    queue.append(next_idx)

                next_idx += 1
                   
        return False

    def canJumpSingle(self, nums: List[int]) -> bool:
        last_good_idx = len(nums) - 1
        idx = last_good_idx
        while idx >= 0:
            if nums[idx] + idx >= last_good_idx:
                print(f'Last good index is now: {idx}')
                last_good_idx = idx
                
            idx -= 1
                
        return last_good_idx == 0
                

if __name__ == '__main__':
    nums = [5,4,3,2,1,0,0]
    setrecursionlimit(11000)
    print(Solution().canJump(nums))

