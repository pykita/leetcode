class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        left, right, final = [1] * len(nums), [1] * len(nums), [1] * len(nums)
        
        left_product = 1
        for idx in range(0, len(nums)):
            if idx == 0:
                continue
            
            left_product *= nums[idx - 1]
            left[idx] = left_product
            
        right_product = 1
        for idx in range(len(nums) - 1, -1, -1):
            if idx == len(nums) - 1:
                continue
            
            right_product *= nums[idx + 1]
            right[idx] = right_product
            
        for idx in range(0, len(nums)):
            final[idx] = left[idx] * right[idx]
            
        return final
