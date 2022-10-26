class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        left_result = right_result = -1
        is_left_populated = False
        for i,v in enumerate(nums):
            if v == target:
                if not is_left_populated:
                    left_result = right_result = i
                    is_left_populated = True
                else:
                    right_result = i
                    
        
        
        left, right = 0, len(nums) - 1
        while left + 1 < right:
            center = (right + left) // 2
            
            if nums[center] == target:
                left_result, right_result = center, center
                while left_result > 0 and nums[left_result - 1] == target:
                    left_result -= 1
                    
                while right_result + 1 < len(nums) and nums[right_result + 1] == target:
                    right_result += 1
                break
            else:
                print(center)
                if nums[center] > target:
                    right = center
                else:
                    left = center
                    
                
                    
            
                    
        return [left_result, right_result]