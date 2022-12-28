class Solution:
    def mySqrt(self, x: int) -> int:
        if x == 0:
            return 0
        start, end = 0, x
        
        while start < end:
            mid = (end - start) / 2 + start
            
            square_mid = int(mid * mid)
            if square_mid == x:
                break
            
            if square_mid > x:
                end = mid
            else:
                start = mid
            
        return int(mid)
