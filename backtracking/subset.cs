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
}