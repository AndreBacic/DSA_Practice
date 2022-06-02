public class Solution
{
    /// <summary>
    /// where n is candidates.Length and k is target
    /// O(nk) time (worst case)
    /// O(nk) space (worst case)
    /// Because the DFS depth limit is k/min(candidates)
    /// </summary>
    /// <param name="candidates"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        // 8 - 5 = 3 - 3 = 0 [3,5]
        //         3 - 2 = 1 
        // 8 - 3 = 5 - 3 = 2 - 2 = 0 [2,3,3]
        //         5 - 2 = 3 - 2 = 1
        // 8 - 2 = 6 - 2 = 4 - 2 = 0 [2,2,2,2]

        /*
        - subtract from remainder until you hit zero or a number smaller than the smallest candidate
          NOTE that you can only use candidates <= the smallest you've used so far (AKA <= last candidate)
          NOTE that you must try all of the candidates <= last candidate
        
        cs([2,3,5], 8) -> cs([2,3,5], 3) [5,3] -> cs([2], 1) null
                          cs([2,3], 5) -> cs([2,3], 2) [3,3,2]
                                          cs([2], 3) null
                          cs([2], 6) -> cs([2], 4) -> cs([2], 2) [2,2,2,2]
        
        - TODO: Memoize previously tried targets for future reference?        
        */
        Array.Sort(candidates);
        List<IList<int>> output = (List<IList<int>>)DFS(candidates, target);
        foreach (List<int> l in output)
        {
            l.Reverse();
        }
        output.Reverse();
        return output;

    }
    public IList<IList<int>> DFS(int[] candidates, int target)
    {
        IList<IList<int>> output = new List<IList<int>>();

        for (int i = candidates.Length - 1; i >= 0; i--)
        {
            int r = target - candidates[i];
            if (r == 0) output.Add(new List<int>() { candidates[i] });
            else if (r >= candidates[0])
            {
                int[] c = new int[i + 1];
                Array.Copy(candidates, 0, c, 0, i + 1);
                foreach (List<int> l in DFS(c, r))
                {
                    List<int> o = new() { candidates[i] };
                    o.AddRange(l);
                    output.Add(o);
                }
            }

        }
        return output;
    }
}