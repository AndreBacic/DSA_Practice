public class Solution {
    public int LengthOfLongestSubstring(string s) {
        // O(n) time, O(1) space best case, O(n) space worst
        if (s.Length == 0) return 0;
        
        int largest = 0;
        int left = -1;
        Dictionary<char, int> table = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (table.ContainsKey(c) && table[c] >= left) {
                left = table[c];
            }
            table[c] = i;
            largest = Math.Max(i-left, largest);
        }
        return largest;
    }
    public int LengthOfLongestSubstringWithDictReset(string s) {
        // O(n) time, O(1) space best case, O(n) space worst
        if (s.Length == 0) return 0;
        
        int largest = 0;
        int tally = 0;
        Dictionary<char, int> table = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++) {
            char c = s[i];
            if (table.ContainsKey(c) && table[c] >= 0) {
                largest = Math.Max(tally, largest);
                tally = i - table[c] - 1;
                foreach (char k in table.Keys) {
                    if (table[k] < table[c]) table[k] = -1;
                }
            }
            tally += 1;
            table[c] = i;             
        }        
        largest = Math.Max(tally, largest);
        return largest;
    }
}