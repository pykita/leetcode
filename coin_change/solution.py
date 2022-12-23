class Solution:
    
    def coinChange(self, coins: List[int], amount: int) -> int:
        if amount == 0:
            return 0
        s_coins = sorted(coins, reverse=True)
        visited = {}
        def rep_coin_change(coins, amount):
            if amount in visited:
                return visited[amount]
            min_steps = amount + 1
            for coin in coins:
                if coin > amount:
                    continue
                new_amount = amount - coin
                if new_amount == 0:
                    return 1
                else:
                    steps = rep_coin_change(coins, new_amount)
                    visited[new_amount] = steps
                    if steps != -1:
                        min_steps = min(min_steps, steps + 1)
                    
                    
            if min_steps <= amount:
                return min_steps
            else: 
                return -1
            
        return rep_coin_change(s_coins, amount)
