public class Solution
{
    /// <summary>
    /// Admittedly I learned this technique from another submitter
    /// O(n) time, O(n) space (O(1) space not counting the output array)
    /// </summary>
    public int[] CountBits(int n)
    {
        int[] output = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            output[i] = output[i >> 1] + (i & 1); // i & 1 is the same as i % 2 because 1 is 00000001
        }
        return output;
    }
    /// <summary>
    /// O(n * log(n)) time, O(n) space
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public int[] CountBits0(int n)
    {
        int[] output = new int[n + 1];
        output[0] = 0;
        for (int i = 1; i <= n; i++)
        {
            /*
            2 O(n log n) ideas:
            - loop through powers of 2
            - add 1 to string of bits and tally 1's
            - the code below:
            */
            int j = i, s = 0;
            while (j > 0)
            {
                s += j % 2;
                j = j >> 1;
            }
            output[i] = s;
        }
        return output;
    }
}