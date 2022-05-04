public class Solution {
    /// <summary>
    /// Find the maximum contiguous subarray of non negative numbers from an array.
    /// O(n) time and O(1) space.
    /// </summary>
    public int MaxSubArray(int[] nums) {
        if (nums.Length == 1) return nums[0];
        int largest = Int32.MinValue;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++) {
            sum += nums[i];
            if (sum > largest) largest = sum;
            if (sum < 0) sum = 0; 
        }
        return largest;
    }
}