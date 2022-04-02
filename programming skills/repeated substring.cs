public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        int len = (int)Math.Floor((double)(s.Length/2));
        for (int i = 1; i <= len; i++) {
            if (s.Length % i == 0) {
                string sub = s.Substring(0, i);
                int j = i;
                while (j+i <= s.Length) {
                    if (s.Substring(j, i) != sub) {
                        break;
                    }
                    j += i;
                }
                if (j == s.Length) {
                    return true;
                }
            }
        }
        return false;
    }
}