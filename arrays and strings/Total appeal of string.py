from collections import defaultdict


prompt = """ LeetCode #2262: Total appeal of a string
The appeal of a string is the number of distinct characters found in the string.

For example, the appeal of "abbca" is 3 because it has 3 distinct characters: 'a', 'b', and 'c'.
Given a string s, return the total appeal of all of its substrings.

A substring is a contiguous sequence of characters within a string.
 

Example 1:

Input: s = "abbca"
Output: 28
Explanation: The following are the substrings of "abbca":
- Substrings of length 1: "a", "b", "b", "c", "a" have an appeal of 1, 1, 1, 1, and 1 respectively. The sum is 5.
- Substrings of length 2: "ab", "bb", "bc", "ca" have an appeal of 2, 1, 2, and 2 respectively. The sum is 7.
- Substrings of length 3: "abb", "bbc", "bca" have an appeal of 2, 2, and 3 respectively. The sum is 7.
- Substrings of length 4: "abbc", "bbca" have an appeal of 3 and 3 respectively. The sum is 6.
- Substrings of length 5: "abbca" has an appeal of 3. The sum is 3.
The total sum is 5 + 7 + 7 + 6 + 3 = 28.


Example 2:

Input: s = "code"
Output: 20
Explanation: The following are the substrings of "code":
- Substrings of length 1: "c", "o", "d", "e" have an appeal of 1, 1, 1, and 1 respectively. The sum is 4.
- Substrings of length 2: "co", "od", "de" have an appeal of 2, 2, and 2 respectively. The sum is 6.
- Substrings of length 3: "cod", "ode" have an appeal of 3 and 3 respectively. The sum is 6.
- Substrings of length 4: "code" has an appeal of 4. The sum is 4.
The total sum is 4 + 6 + 6 + 4 = 20.
 

Constraints:

1 <= s.length <= 105
s consists of lowercase English letters.
"""

class Solution: # by hanjo108 https://leetcode.com/problems/total-appeal-of-a-string/discuss/1996300/Python3-or-O(N)-O(1)-or-detail-for-beginners
                # O(N) time, O(1) space   (I'm leaving this here as a reminder of how to write great solutions)
                # Basically, hanjo108 discovered a pattern in iterating through the string that let him write this solution.
                # He also kindly wrote a thorough explanation of the pattern in the link above.
    def appealSum(self, s: str) -> int:
        lastSeenMap = {s[0]: 0}
        prev, curr, res = 1, 0, 1
        
        for i in range(1, len(s)):
            if s[i] in lastSeenMap:
                curr = prev + (i - lastSeenMap[s[i]])
            else:
                curr = prev + (i + 1)
            res += curr
            prev = curr
            lastSeenMap[s[i]] = i
        return res

# an even more elegant solution by lee215!:
def appealSum(s):
        last = {}
        res = 0
        for i,c in enumerate(s):
            last[c] = i + 1
            res += sum(last.values())
        return res

# another by geekykant:
class Solution3:
    def appealSum(self, s: str) -> int:
        res, n, prev = 0, len(s), defaultdict(lambda: -1)
        for i, ch in enumerate(s):
            res += (i - prev[ch]) * (n - i)
            prev[ch] = i
        return res