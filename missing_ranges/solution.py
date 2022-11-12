class Solution:
    def findMissingRanges(self, nums: List[int], lower: int, upper: int) -> List[str]:
        start_range = lower
        ranges = []
        
        for num in nums:
            if start_range is not None: 
                curr_range = None
                if start_range == num - 1:
                    curr_range = str(start_range)
                elif start_range < num - 1:
                    curr_range = f'{start_range}->{num - 1}'
                
                if curr_range is not None:
                    ranges.append(curr_range)
                
                start_range = num + 1 
            else:
                start_range = num + 1
                
        if start_range == upper:
            ranges.append(str(start_range))
        elif start_range < upper:
            ranges.append(f'{start_range}->{upper}')
                
        return ranges
