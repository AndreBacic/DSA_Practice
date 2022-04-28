public class Solution {
    /// <summary>
    /// Find the index of the target in the rotated sorted array.
    /// This algorithm doesn't tailor the search based on the known initial conditions.
    /// </summary>
    public int Search(int[] nums, int target) {
        if (nums == null || nums.Length == 0) {
            return -1;
        }

        int l = 0;
        int r = nums.Length - 1;
        int m;

        while (l <= r) {
            m = l + (r - l) / 2;
            if (nums[m] == target) {
                return m;
            }

            if (nums[l] <= nums[m]) {
                if (nums[l] <= target && target < nums[m]) {
                    r = m - 1;
                } else {
                    l = m + 1;
                }
            } else {
                if (nums[m] < target && target <= nums[r]) {
                    l = m + 1;
                } else {
                    r = m - 1;
                }
            }
        }

        return -1;
    }
    /// <summary>
    /// Find the index of the target in the rotated sorted array.
    /// 
    /// This code repeats the search algorithm three times, each time tailoring it to a different situation.
    /// 1) The array is not rotated.
    /// 2) The array is rotated, and the target is larger than the first element.
    /// 3) The array is rotated, and the target is smaller than the last element.
    /// </summary>
    public int SearchVerbose(int[] nums, int target) {
        // brute force way:
        /*
        int output = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                output = i;
                break;
            }
        }
        return output;
        */

        if (nums.Length == 0) return nums[0] == target ? 0 : -1;
        
        int first = nums[0];
        int last = nums[nums.Length - 1];
        if (target == first) return 0;
        if (target == last) return nums.Length - 1;

        if (first < last) {
            int l = 0;
            int r = nums.Length - 1;
            int m;
            while (l <= r) {
                m = (l + r) / 2;
                if (nums[m] == target) return m;
                if (nums[m] < target) {
                    l = m + 1;
                }
                else {
                    r = m - 1;
                }
            }
        }
        else if (target < first && target > last) return -1;
        else if (target > first) {
            int l = 0;
            int r = nums.Length - 1;
            int m;
            while (l <= r) {
                m = (l + r) / 2;
                if (nums[m] == target) return m;
                if (nums[m] < target) {
                    if (nums[m] < first) {
                        r = m - 1;
                    }
                    else {
                        l = m + 1;
                    }
                }
                else {
                    r = m - 1;
                }
            }
        }
        else { // target < last
            int l = 0;
            int r = nums.Length - 1;
            int m;
            while (l <= r) {
                m = (l + r) / 2;
                if (nums[m] == target) return m;
                if (nums[m] < target) {
                    l = m + 1;
                }
                else {
                    if (nums[m] > last) {
                        l = m + 1;
                    }
                    else {
                        r = m - 1;
                    }
                }
            }
        }
        return -1;
    }
}