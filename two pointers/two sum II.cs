public class Solution {
    /// <summary>
    /// TWO SUM II
    /// Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, 
    /// find two numbers such that they add up to a specific target number. 
    /// Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
    ///
    /// Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.
    /// The tests are generated such that there is exactly one solution. You may not use the same element twice.
    ///
    /// O(n) time, O(1) space
    /// </summary>
    public int[] TwoSum(int[] numbers, int target) {
        int i = 0;
        int j = numbers.Length-1;
        while (i < j) {
            int s = numbers[i] + numbers[j];
            if (s == target) return new int[2] {i+1,j+1}; // add one to indices because input array is supposedly 1-indexed
            else if (s < target) i++;
            else j--;
        }
        return new int[2] {i+1,j+1}; // code should never reach here, but C# compiler throws an error if we don't return something
    }
}