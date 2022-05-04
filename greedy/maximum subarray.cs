public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums.Length == 1) {
            return nums[0];
        }
        // brute force!
        int largest = Int32.MinValue;
        for (int i = 0; i < nums.Length; i++) {
            int sum = 0;
            for (int j = i; j < nums.Length; j++) {
                sum += nums[j];
                if (sum > largest) {
                    largest = sum;
                }
            } 
        }
        return largest;
    }
}