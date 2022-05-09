/// <summary>
/// What I submitted after a hint
/// </summary>
public class SolutionSubmitted {
    public int MaxProfit(int[] prices) {
        int l = int.MaxValue;
        int h = -1;
        int max = 0;

        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < l) {
                l = prices[i];
                h = -1; // reset h
            }
            if (prices[i] > h) {
                h = prices[i];
                max = Math.Max(max, h - l);
            }
        }

        return max;
    }
}

/// <summary>
/// LeetCode solution.
/// </summary>
public class Solution {
    public int MaxProfit(int[] prices) {
        int minprice = int.MaxValue;
        int maxprofit = 0;
        for (int i = 0; i < prices.length; i++) {
            if (prices[i] < minprice)
                minprice = prices[i];
            else if (prices[i] - minprice > maxprofit)
                maxprofit = prices[i] - minprice;
        }
        return maxprofit;
    }
}

/*
/// <summary> 
/// This solution doesn't work for a case where the max profit is after the max high and before the min low ([4, 2, 3, 1] returns 0)
/// </summary>
public class SolutionNeg1 {
    public int MaxProfit(int[] prices) {
        if (prices.Length <= 1) return 0;

        int l1 = 100001;  // LeetCode guarantees that 0 < prices[i] < 10^4
        int h1 = -1;
        int li = -1, hi = -1;

        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < l1) { l1 = prices[i]; li = i; }
            if (prices[i] > h1) { h1 = prices[i]; hi = i; }
        }

        if (li <= hi) { // if the max high and low are the same, then there is no profit and zero is returned
            return h1 - l1;
        }

        /// so, if the max high comes before the min low, then the max profit is 
        /// either between the max high and min low before it,
        /// or between the min low and max high after it
        int l2 = 100001, h2 = -1;

        for (int i = 0; i < hi; i++) {
            if (prices[i] < l2) l2 = prices[i];
        }
        for (int i = li + 1; i < prices.Length; i++) {
            if (prices[i] > h2) h2 = prices[i];
        }

        int max = Math.Max(h1 - l2, h2 - l1);
        if (max < 0) max = 0;
        return max;
    }
}
*/

class Program {
    static void Main(string[] args) {
        Solution s = new Solution();
        int[] prices = { 7,6,4,3,1 };
        Console.WriteLine(s.MaxProfit(prices));
    }
}