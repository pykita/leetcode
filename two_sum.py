class Solution:
    def find_lower_or_equal_index(self, sorted_nums, target):
        if sorted_nums[0][1] > 0:
            i = len(sorted_nums) - 1
            while target <= sorted_nums[i][1]:
                i -= 1
                if i < 0:
                    break
            else:
                return i

        return len(sorted_nums) - 1

    def twoSum(self, nums, target):
        sorted_nums = sorted(enumerate(nums), key=lambda i: i[1])
        upper_boundary = self.find_lower_or_equal_index(sorted_nums, target) + 1
        for i in range(0, upper_boundary):
            for j in range(i + 1, upper_boundary):
                if sorted_nums[i][1] + sorted_nums[j][1] == target:
                    return [sorted_nums[i][0], sorted_nums[j][0]]

def main():
    print(Solution().twoSum([-1,-2,-3,-4,-5], -8))

if __name__ == '__main__':
    main()