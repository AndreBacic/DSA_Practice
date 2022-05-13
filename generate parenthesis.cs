using System;
using System.Collections.Generic;
public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        // n=1 : ()
        // n=2 : (()), ()()
        // n=3 : ((())), (()()), (())(), ()(()), ()()()
        // n=4 : (((()))), ((()())), ((()))(), ()((())), (()(())), (()()()), (()())(), (())(()), ()(()()), ()()()()
        // strategy:
        // 1 for each increment of n, first wrap the last n-1 parentheses with ()
        // 2 take the lists of n-x and x parentheses and combine them (except for the combo where it's all () in a row) [ex: n=4, x=1, list=["((()))()", "(()())()", "(())()()", "()(())()"], excluded: "()()()()"]
        // 3 end with n pairs of ()
        // 4 memoize 1-3
        // 5 lastly, sort output lexicographically
        
        if (n < 1) return new List<string>( );

        if (n == 1) return new List<string>() { "()" };

        List<List<string>> memoized = new List<List<string>>();
        memoized.Add(new List<string>() { "()" });

        for (int i = 1; i < n; i++) {
            var more_output = new List<string>();
            // wrap the last n-1 parentheses with ()
            foreach (var st in memoized[i-1]) {
                more_output.Add($"({st})");
            }
            // pair combinations of < n lists together, and exclude the combo where it's all () in a row
            int x = 0;
            foreach (var l in memoized) {
                foreach (var s1 in l) {
                    foreach (var s2 in memoized[i-x-1]) {
                        string combo = s1 + s2;
                        if (more_output.Contains(combo)) continue;
                        more_output.Add(combo);
                        
                    }
                }
                more_output.RemoveAt(more_output.Count - 1);
                x++;
            }

            // end with n pairs of ()
            string s = "";
            for (int j = 0; j <= i; j++) {
               s+= "()";
            }
            more_output.Add(s);

            memoized.Add(more_output);
        }

        // lastly, sort output lexicographically
        List<string> output = memoized[memoized.Count - 1];
        output.Sort();
        return output;
    }
}

class Program {
    static void Main(string[] args) {
        Solution s = new Solution();
        IList<string> output = s.GenerateParenthesis(4);
        Console.WriteLine("\n\nRESULTS:\n");
        foreach (var st in output) {
            Console.WriteLine(st);
        }
    }
}
