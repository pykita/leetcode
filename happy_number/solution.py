class Solution:
    def isHappy(self, n: int) -> bool:
        #0, 1, 4, 9, 16, 25, 36, 49, 64, 81
        unsuccessful_sums = set()
        curr_n = n
        while True:
            sum = 0
            while curr_n > 0:
                next_digit = curr_n % 10
                sum += next_digit ** 2
                curr_n //= 10
            
            if sum == 1:
                return True
            elif sum in unsuccessful_sums:
                return False
            else:
                unsuccessful_sums.add(sum)
                curr_n = sum
