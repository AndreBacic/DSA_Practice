public class Solution
{
    /// <summary>
    /// O(min(m, n)) time, O(1) space
    /// </summary>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public int UniquePaths(int m, int n)
    {
        if (m > n) (m, n) = (n, m);

        long num = 1, denom = 1;

        for (int i = 1; i < m; i++)
        {
            num *= n;
            n++;
        }
        for (int j = m - 1; j > 1; j--) denom *= j;

        return (int)(num / denom);
    }
}