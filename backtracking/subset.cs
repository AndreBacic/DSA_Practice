using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        // ALL numbers in nums are unique
        // output length is 2^n * n/2 (average length of set is n/2)
        // therefore O of time and space are minimum O(n 2^n)
        IList<IList<int>> output = new List<IList<int>>();
        output.Add(new List<int>()); //empty set
        foreach (int n in nums) {
            int l = output.Count;
            for (int i = 0; i < l; i++) {
                List<int> newList = new List<int>(output[i]);
                newList.Add(n);
                output.Add(newList);
            }            
        }
        return output;
    }
    /// <summary>
    /// Backtracking solution
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> Subsets_with_backtracking(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        backtrack(output, new List<int>(), nums, 0);
        return output;
    }
    private void backtrack(IList<IList<int>> output, List<int> curr, int[] nums, int start) {
        if (start == nums.Length) {
            output.Add(new List<int>(curr));
            return;
        }
        backtrack(output, curr, nums, start + 1);
        curr.Add(nums[start]);
        backtrack(output, curr, nums, start + 1);
        curr.RemoveAt(curr.Count - 1);
    }
}

class Program {
    static void Main(string[] args) {
        Solution s = new Solution();
        int[] nums = {1, 2, 3};
        IList<IList<int>> output = s.Subsets_with_backtracking(nums);
        foreach (IList<int> list in output) {
            Console.Write("[  ");
            foreach (int n in list) {
                Console.Write(n + " ");
            }
            Console.WriteLine(" ]");
        }
    }
}