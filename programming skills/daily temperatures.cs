public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
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