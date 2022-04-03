using System;
using System.Collections.NonGeneric;
using System.Linq;

public class Solution {
    /// <summary>
    /// Evaluate the value of an arithmetic expression in Reverse Polish Notation.
    /// Valid operators are +, -, *, /. Each operand may be an integer or another expression.
    /// Input (from LeetCode) is guaranteed to be always valid.
    /// </summary>
    public int EvalRPN(string[] tokens) {
        // Note: integer division should truncate towards zero (which is built-in to C# integer division! :) )
        if (tokens.Length == 1) { // min length is 1,  but will not be 2 because that would require invalid input
            return int.Parse(tokens[0]);
        }
        string[] operators = { "+", "-", "*", "/" };

        Stack<int> stack = new Stack<int>();
        // go through tokens until we find an operator, 
        // then pop 2 numbers off the stack, perform the operation, 
        // and push the result back on the stack.

        foreach (string token in tokens) {
            if (operators.Contains(token)) {
                int n2 = stack.Pop();
                int n1 = stack.Pop();
                int result = 0;
                if  (token == operators[0]) {
                    result = n1 + n2;
                } else if (token == operators[1]) {
                    result = n1 - n2;
                } else if (token == operators[2]) {
                    result = n1 * n2;
                } else if (token == operators[3]) {
                    result = n1 / n2;
                }
                stack.Push(result);
            }
            else {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop(); // only one number left on the stack, the correct answer :D
    }
}


/// <summary>
/// 64ms (fastest) solution for LeetCode's Evaluate Reverse Polish Notation problem.
/// </summary>
public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var token in tokens) {
            if (int.TryParse(token, out var value)) {
                stack.Push(value);
                continue;
            }
            var right = stack.Pop();
            var left = stack.Pop();
            var result = token switch {
                "+" => left + right,
                "-" => left - right,
                "*" => left * right,
                "/" => left / right,
                _ => throw new NotSupportedException()
            };
            stack.Push(result);
        }
        return stack.Pop(); // using stack.Peek() might be actually faster
    }
}