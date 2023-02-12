class Comparator(str):
    def __lt__(x, y):
        return x+y < y+x

class Solution:
    def largestNumber(self, nums: List[int]) -> str:
        largest_number = ''.join(sorted(map(str,nums), key=Comparator, reverse=True))
        return '0' if largest_number[0] == '0' else largest_number
