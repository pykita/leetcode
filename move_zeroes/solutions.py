class Solution:
    def moveZeroes(self, nums: List[int]) -> None:
        cur, lazy_cur = 0,0
        
        while cur < len(nums):
            if nums[cur] != 0:
                nums[cur], nums[lazy_cur] = nums[lazy_cur], nums[cur]
                lazy_cur += 1
                
            cur += 1
            
        
            