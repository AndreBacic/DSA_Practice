public class Solution
{
    /// <summary>
    /// Where n is strs.Length, and m is the average strs[i].Length
    /// O(n m log m) time, O(n m) space (worst case)
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public IList<IList<string>> GroupAnagrams0(string[] strs)
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

    /// <summary>
    /// Since strs[i] will contain only lowercase English letters, we can use a 26-element array to represent the count of each letter.
    /// 
    /// Where n is strs.Length, and m is the average strs[i].Length
    /// O(n m) time, O(n m) space
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> d = new();
        foreach (string s in strs)
        {
            int[] a = new int[26];
            foreach (char c in s) a[c - 'a']++;
            // convert a to a string because arrays are reference types
            string t = string.Join(",", a);
            if (d.ContainsKey(t)) d[t].Add(s);
            else d.Add(t, new List<string>() { s });
        }

        return d.Values.ToList();
    }
}