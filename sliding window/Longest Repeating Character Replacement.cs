public class Solution {


    
    /// <summary>
    /// First attempt: works, but is very slow.
    /// O(n^2) time, O(1) space
    /// </summary>
    public int CharacterReplacement0(string s, int k) {
        if (k >= s.Length-1) return s.Length; // we can make the entire string the same letter        
        
        int largest = k+1; // minimum longest if all letters are unique
        
        for (int i = 0; i < s.Length; i++) {
            char l = s[i];
            int c = k, n = 1;
            for (int j = i+1; j < s.Length; j++) {
                if (s[j] == l) {
                    n++;
                    if (c == k) i=j; // update i to skip over repeated letters
                }
                else {
                    if (c==0) break;
                    n++;
                    c--;
                }
            }
            n+=c;
            largest = Math.Max(n, largest);
        }        
        
        return Math.Min(largest, s.Length); // largest can be greater than s.Length if k is big enough to add extra letters
    }
}