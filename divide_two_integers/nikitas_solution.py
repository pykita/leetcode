class Solution:
    min_result = 2 ** 31 * -1
    max_result = 2 ** 31 - 1
    
    def return_min_or_max(self, result: int) -> int:
        if result > self.max_result:
            return self.max_result
        
        if result < self.min_result:
            return self.min_result
        
        return result
    
    def divide_subtraction(self, dividend: int, divisor: int) -> int:
        counter = 0
        while dividend >= divisor:
            dividend -= divisor
            counter += 1
            
        return counter, dividend
    
    def get_final_sign(self, dividend: int, divisor: int) -> int:
        return 1 if (dividend >= 0 and divisor >= 0) or (dividend < 0 and divisor < 0) else -1
    
    def divide(self, dividend_signed: int, divisor: int) -> int:
        sign = self.get_final_sign(dividend_signed, divisor)
        dividend, divisor = abs(dividend_signed), abs(divisor)
        dividend_str = str(dividend)
        
        quotient_str = ''
        remainder = 0
        curr_num_str = ''
        
        for num in dividend_str:
            curr_num_str += str(remainder) + num if remainder else num
            curr_num_int = int(curr_num_str)
            remainder = 0
            
            if curr_num_int >= divisor:
                tmp_quotinent, remainder = self.divide_subtraction(curr_num_int, divisor)
                quotient_str += str(tmp_quotinent)
                curr_num_str = ''
            else:
                quotient_str += '0'
                
            
                
        quotinent_int = int(quotient_str) * sign
        
        return self.return_min_or_max(quotinent_int) 
