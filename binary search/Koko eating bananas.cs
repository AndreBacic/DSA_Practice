public class Solution
{
    /// <summary>
    /// Unoptimized O(n*m) time, O(1) space where m is the largest value in piles and n is piles.Length
    /// First sums the piles and computes the minimum speed if all piles are equal, and then increments min speed until all the piles can be consumed in h hours.
    /// </summary>
    /// <param name="piles"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public int MinEatingSpeed0(int[] piles, int h)
    {
        // h is always >= piles.length so there is always a solution
        double s = 0;
        foreach (int p in piles) s += p;
        int m = (int)Math.Ceiling(s / h);
        while (true)
        {
            int l = h;
            for (int i = 0; i < piles.Length; i++)
            {
                l -= (int)Math.Ceiling((double)piles[i] / m);
            }
            if (l >= 0) break;
            m++;
        }
        return m;
    }
}