
/// <summary>
/// Given an array of integers temperatures represents the daily temperatures, 
/// return an array answer such that answer[i] is the number of days you have to wait 
/// after the ith day to get a warmer temperature. If there is no future day for which 
/// this is possible, keep answer[i] == 0 instead.
/// </summary>
public class Solution {
    /// <summary>
    /// O(n) time and O(1) space (output isn't counted in space).
    /// While I came up with the lower two solutions here, I copied this one from LeetCode.
    /// </summary>
    public int[] DailyTemperatures(int[] temperatures) {
        int n = temperatures.Length;
        int hottest = 0;
        int[] answer = new int[n];
        
        for (int currDay = n - 1; currDay >= 0; currDay--) {
            int currentTemp = temperatures[currDay];
            if (currentTemp >= hottest) {
                hottest = currentTemp;
                continue;
            }
            
            int days = 1;
            while (temperatures[currDay + days] <= currentTemp) {
                // Use information from answer to search for the next warmer day
                days += answer[currDay + days];
            }
            answer[currDay] = days;
        }
        
        return answer;
    }
    /// <summary>
    /// O(n) time and O(n) space.
    /// </summary>
    public int[] DailyTemperaturesWithStack(int[] temperatures) {
        int[] answer = new int[temperatures.Length];
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (stack.Count > 0 && temperatures[i] > temperatures[stack.Peek()])
            {
                int index = stack.Pop();
                answer[index] = i - index;
            }
            stack.Push(i);
        }
        return answer;
    }
    /// <summary>
    /// O(n^2) time and O(1) space.
    /// </summary>
    public int[] DailyTemperaturesSLow(int[] temperatures) {
        int[] answer = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length-1; i++)
        {
            int j = i + 1;
            while (j < temperatures.Length)
            {
                if (temperatures[j] > temperatures[i])
                {
                    answer[i] = j - i;
                    break;
                }
                j++;
            }
        }

        return answer;
    }
}