public class Solution
{
    /// <summary>
    /// O( n * log(m) ) time (worst case), O(1) space.   (where m is the largest value in piles and n is piles.Length)
    /// First sums the piles and computes the minimum speed if all piles are equal and memoizes the max pile, 
    /// and then binary searches between the minimum speed and the max pile to find the minimum speed, iterating through the piles each time.
    /// </summary>
    /// <param name="piles"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public int MinEatingSpeed(int[] piles, int h)
    {
        // h is always >= piles.length so there is always a solution
        double s = 0;
        int k = 0;
        foreach (int p in piles) { s += p; k = Math.Max(k, p); }
        int j = (int)Math.Ceiling(s / h);
        int found = -1;
        while (j <= k)
        {
            int m = (j + k) / 2;
            int l = h;
            for (int i = 0; i < piles.Length; i++)
            {
                l -= (int)Math.Ceiling((double)piles[i] / m);
            }
            if (l >= 0) { found = m; k = m - 1; }
            else j = m + 1;
        }
        return found;
    }
}