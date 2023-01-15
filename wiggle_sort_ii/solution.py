# This "brilliant solution didn't work - was broken by 4556 example"
class Solution:
    def wiggleSort(self, nums: List[int]) -> None:
        """
        Do not return anything, modify nums in-place instead.
        """
        no_swap_count = 0
        is_less = True

        for idx in range(len(nums) - 1):
            if nums[idx] == nums[idx + 1]:
                no_swap_count += 1
            else:
                if no_swap_count > 0:
                    offset = no_swap_count if nums[idx] > nums[idx + 1] else no_swap_count - 1
                    nums[idx - offset], nums[idx + 1] = nums[idx + 1], nums[idx - offset]
                    no_swap_count -= 1
                elif (is_less and nums[idx] > nums[idx + 1]) or \
                    (not is_less and nums[idx] < nums[idx + 1]):
                    nums[idx], nums[idx + 1] = nums[idx + 1], nums[idx]

            is_less = not is_less
