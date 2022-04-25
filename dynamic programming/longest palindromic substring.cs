public class Solution0 {
    /// <summary>
    /// My original idea but the variables l2 and l1 are actually unnecessary.
    /// More importantly, the expand around center method returns a string instead of int, 
    /// which causes the space complexity to be O(n^2) (I think, maybe the garbage collector makes the space complexity O(1)).
    ///
    /// O(n^2) time and O(n) space.
    /// </summary>
    public string LongestPalindrome(string s) {
        if (s == null || s.Length == 0) {
            return "";
        }
        if (s.Length == 1) {
            return s;
        }
        string longest = s[0].ToString();
        char? l2 = null;
        char? l1 = null;
        for (int i = 0; i < s.Length; i++)
        {
            if (l2 == s[i])
            {
                // expand about this len 3 palindrome
                string newpal = ExpandAroundCenter(s, i - 3, i + 1);
                if (newpal.Length > longest.Length)
                {
                    longest = newpal;
                }
            }
            if (l1 == s[i]) {
                // expand about this len 2 palindrome
                string newpal = ExpandAroundCenter(s, i - 2, i + 1);
                if (newpal.Length > longest.Length)
                {
                    longest = newpal;
                }
            }

            l2 = l1;
            l1 = s[i];
        }

        return longest;
    }

    private string ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return s.Substring(left + 1, right - left - 1);
    }
}

/// <summary>
/// This solution improves off of Solution0, reducing the space complexity to O(1)
/// by not using strings or those unnecessary variables.
/// Overall runtime is reduced by not having to allocate strings to memory.
///
/// I confess that I had to look at the LeeCode solution to know to do this (but I did come up with the algorithm ^).
///
/// O(n^2) time and O(1) space.
/// </summary>
public class Solution {
    public string LongestPalindrome(string s) {
        if (s == null || s.Length == 0) {
            return "";
        }
        if (s.Length == 1) {
            return s;
        }
        int maxLen = 0;
        int start = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int evenLen = ExpandAroundCenter(s, i, i);
            int oddLen = ExpandAroundCenter(s, i, i + 1);
            int len = Math.Max(evenLen, oddLen);
            if (len > maxLen)
            {
                maxLen = len;
                start = i - (len - 1) / 2; // C# rounds down in integer division
            }
            
        }
        return s.Substring(start, maxLen);
    }

    private int ExpandAroundCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }
}

public class ManachersAlgorithm {
    public string LongestPalindrome(string s) {
        // uses Manacher's algorithm to find the longest palindrome in a string
        // O(n) time and O(n) space        
        // https://en.wikipedia.org/wiki/Longest_palindromic_substring#Manacher's_algorithm
        // NOTE: This code was generated with GitHub Copilot.
        // TODO: THIS CODE DOES NOT WORK AND MUST BE DEBUGGED AT SOME POINT

        if (s == null || s.Length == 0) {
            return "";
        }
        if (s.Length == 1) {
            return s;
        }
        int maxLen = 0;
        int start = 0;
        string T = preProcess(s);
        int[] P = new int[T.Length];
        int C = 0;
        int R = 0;
        for (int i = 1; i < T.Length - 1; i++)
        {
            int i_mirror = 2 * C - i;
            P[i] = (R > i) ? Math.Min(R - i, P[i_mirror]) : 0;
            // Attempt to expand palindrome centered at i
            while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
            {
                P[i]++;
            }
            // If palindrome centered at i expand past R,
            // adjust center based on expanded palindrome.
            if (i + P[i] > R)
            {
                C = i;
                R = i + P[i];
            }
            // Find the maximum element in P.
            if (P[i] > maxLen)
            {
                maxLen = P[i];
                start = (i - C) / 2;
            }
        }
        return s.Substring(start, maxLen);
    }

    private string preProcess(string s)
    {
        // Adds a '^' and an '$' to the beginning and end of the string.
        // This is done so that the string is not treated as a substring of itself.
        // O(n) time and O(n) space.
        // https://en.wikipedia.org/wiki/Longest_palindromic_substring#Manacher's_algorithm
        // NOTE: This code was generated with GitHub Copilot.

        string T = "^";
        for (int i = 0; i < s.Length; i++)
        {
            T += "#" + s[i];
        }
        T += "#$";
        return T;
    }
}