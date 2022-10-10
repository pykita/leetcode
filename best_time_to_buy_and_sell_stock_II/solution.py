class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        if len(prices) < 2:
            return 0
        first, second = 0, 1
        result = 0
        
        while second != len(prices):
            if prices[first] < prices[second]:
                result += prices[second] - prices[first]
                
            first += 1
            second += 1
                
        return result