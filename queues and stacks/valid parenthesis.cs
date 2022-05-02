public class Solution {
    /// <summary>
    /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determines if the input string is valid.
    /// The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
    ///
    /// O(n) time and O(n) space
    /// </summary>
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(' || s[i] == '[' || s[i] == '{') {
                stack.Push(s[i]);
            } else {
                if (stack.Count == 0) {
                    return false;
                }
                char c = stack.Pop();
                if (c == '(' && s[i] != ')') {
                    return false;
                }
                if (c == '[' && s[i] != ']') {
                    return false;
                }
                if (c == '{' && s[i] != '}') {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }
}

/// <summary>
/// Leetcode #20 Valid Parentheses best memory solution
/// by some guy on leetcode
/// </summary>
public class Solution {
    private readonly Dictionary<char, char> _oppositeSymbols = new()
    {
        {')', '('},
        {'}', '{'},
        {']', '['}
    };
    
    public bool IsValid(string s) {
        // stack implementation
        var list = new List<char>(s.Length);

        foreach (var c in s)
        {
            if (list.Count == 0
                || !_oppositeSymbols.TryGetValue(c, out var opposite))
            {
                list.Add(c);
                continue;
            }

            var last = list.Last();
            if (last != opposite)
            {
                list.Add(c);
                continue;
            }

            list.RemoveAt(list.Count - 1);
        }

        return list.Count == 0;
    }
}