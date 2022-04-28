using System;
using System.Linq;

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
    /// <summary>
    /// Manacher's algorithm, taken from Wikipedia and transpiled from psuedocode to C#.
    /// O(n) time and O(n) space.
    ///
    /// Source url:
    /// https://en.wikipedia.org/wiki/Longest_palindromic_substring#Manacher's_algorithm
    /// </summary>
    public string LongestPalindrome(string S) {
        // S with a bogus character (eg. '|') inserted between each character (including outer boundaries)
        string s = "|" + string.Join("|", S.Select(c => c.ToString())) + "|";
        int[] PalindromeRadii = new int[s.Length]; // The radius of the longest palindrome centered on each place in s
        // note: length(s) = length(PalindromeRadii) = 2 × length(S) + 1
        
        int Center = 0;
        int Radius = 0;
        
        while (Center < s.Length) {
            // At the start of the loop, Radius is already set to a lower-bound for the longest radius.
            // In the first iteration, Radius is 0, but it can be higher.
            
            // Determine the longest palindrome starting at Center-Radius and going to Center+Radius
            while (Center-(Radius+1) >= 0 && Center+Radius+1 < s.Length && s[Center-(Radius+1)] == s[Center+Radius+1]) {
                Radius++;
            }             
         
            // Save the radius of the longest palindrome in the array
            PalindromeRadii[Center] = Radius;
            
            // Below, Center is incremented.
            // If any precomputed values can be reused, they are.
            // Also, Radius may be set to a value greater than 0
            
            int OldCenter = Center;
            int OldRadius = Radius;
            Center++;
            // Radius' default value will be 0, if we reach the end of the following loop. 
            Radius = 0;
            while (Center <= OldCenter + OldRadius) {
                // Because Center lies inside the old palindrome and every character inside
                // a palindrome has a "mirrored" character reflected across its center, we
                // can use the data that was precomputed for the Center's mirrored point. 
                int MirroredCenter = OldCenter - (Center - OldCenter);
                int MaxMirroredRadius = OldCenter + OldRadius - Center;
                if (PalindromeRadii[MirroredCenter] < MaxMirroredRadius) {
                    PalindromeRadii[Center] = PalindromeRadii[MirroredCenter];
                    Center++;
                }   
                else if (PalindromeRadii[MirroredCenter] > MaxMirroredRadius) {
                    PalindromeRadii[Center] = MaxMirroredRadius;
                    Center++;
                }   
                else { // PalindromeRadii[MirroredCenter] = MaxMirroredRadius
                    Radius = MaxMirroredRadius;
                    break; // exit while loop early
                }   
            }      
        }
        int maxRadius = -1;
        int maxRadiusIndex = -1;
        for (int i = 0; i < PalindromeRadii.Length; i++) {
            if (PalindromeRadii[i] > maxRadius) {
                maxRadius = PalindromeRadii[i];
                maxRadiusIndex = i/2;
            }
        }
        
        int longest_palindrome_in_s = 2*maxRadius+1;
        // longest_palindrome_in_s = 2*max(PalindromeRadii)+1;
        int longest_palindrome_in_S = (longest_palindrome_in_s - 1)/2; // = PalindromeRadii.Max() == maxRadius
        
        //Console.WriteLine($"{maxRadius} {maxRadiusIndex}    {S}    {s}");
        string output = S.Substring(maxRadiusIndex - longest_palindrome_in_S/2, longest_palindrome_in_S);
        return output;
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Solution s = new Solution();
        ManachersAlgorithm m = new ManachersAlgorithm();
        string test1 = "babad";
        string test2 = "cbbd";
        string test3 = "abacdfgdcaba";
        //Console.WriteLine(s.LongestPalindrome(test1));
        Console.WriteLine(m.LongestPalindrome(test1));
        Console.WriteLine(m.LongestPalindrome(test2));
        Console.WriteLine(m.LongestPalindrome(test3));
    }
}


// Another C# Manacher's Algorithm implementation by @cloudpbxtrunc1 on LeetCode
public class ManachersAlgorithm2 {
    public string LongestPalindrome_Manacher2(string s) {
        if (s.Length == 0)
        {
            return "";
        }

        string T = preProcess(s);
        int n = T.Length;
        int[] P = new int[n];
        int C = 0, R = 0;

        for (int i = 1; i < n - 1; i++)
        {
            int i_mirror = 2 * C - i; // equals to i' = C - (i-C)

            P[i] = (R > i) ? Math.Min(R - i, P[i_mirror]) : 0;

            // Attempt to expand palindrome centered at i
            while (T[i + 1 + P[i]] == T[i - 1 - P[i]])
                P[i]++;

            // If palindrome centered at i expand past R,
            // adjust center based on expanded palindrome.
            if (i + P[i] > R)
            {
                C = i;
                R = i + P[i];
            }
        }

        // Find the maximum element in P.
        int maxLen = 0;
        int centerIndex = 0;
        for (int i = 1; i < n - 1; i++)
        {
            if (P[i] > maxLen)
            {
                maxLen = P[i];
                centerIndex = i;
            }
        }

        return s.Substring((centerIndex - 1 - maxLen) / 2, maxLen);
    }

    private string preProcess(string s) {
        StringBuilder sb = new StringBuilder(s.Length * 2 + 3);
        sb.Append('^');

        foreach (char c in s)
        {
            sb.Append('#');
            sb.Append(c);
        }

        sb.Append("#$");

        return sb.ToString();
    }
}