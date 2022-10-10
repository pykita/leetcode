ArrayBuilder a = new ArrayBuilder();


public class Solution {
    public int MaxProfit(int[] prices)
    {
        var result = 0;
        for (int i = 0; i < prices.Length  - 1; i++)
        {
            if (prices[i] <= prices[i + 1])
            {
                result += prices[i + 1] - prices[i];
            }
        }
        
        return result;
    }
}
