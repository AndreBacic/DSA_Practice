public class Solution {
    /// <summary>
    /// Given an array of integers where all but one of the integers occur twice,
    /// find the one that occurs only once.
    /// O(n) time, O(1) space
    /// </summary>
    public int SingleNumber(int[] nums) {
        int output = 0;
        foreach (int n in nums) output ^= n; // output XOR equals n
        return output;
    }
}