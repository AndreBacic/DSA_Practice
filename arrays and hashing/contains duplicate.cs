public class Solution {
    // O(n) time, O(n) space
    // A solution that first sorts the array has O(n log n) time and O(1) space.
    public bool ContainsDuplicate(int[] nums) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            if (dict.ContainsKey(nums[i])) return true;            
            dict.Add(nums[i], 1);            
        }
        return false;
    }
}