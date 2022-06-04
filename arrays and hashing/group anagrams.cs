public class Solution
{
    /// <summary>
    /// Where n is strs.Length, and m is the average strs[i].Length
    /// O(n m log m) time, O(n m) space (worst case)
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        List<IList<string>> output = new();

        Dictionary<string, int> d = new();
        foreach (string s in strs)
        {
            char[] a = s.ToCharArray();
            Array.Sort(a);
            string t = new string(a);
            if (d.ContainsKey(t)) output[d[t]].Add(s);
            else
            {
                output.Add(new List<string>() { s });
                d.Add(t, output.Count - 1);
            }
        }

        return output;
    }
}