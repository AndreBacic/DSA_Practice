public class Solution {
    public IList<int> AddToArrayForm(int[] num, int k) {
        int[] ks = k.ToString().ToCharArray().Select(c => c - '0').ToArray();
        Array.Reverse(ks);
        Array.Reverse(num);
        List<int> result = new List<int>();

        int carry = 0;
        for (int i = 0; i < num.Length || i < ks.Length; i++) {
            int sum = carry;
            if (i < num.Length) sum += num[i];
            if (i < ks.Length) sum += ks[i];
            carry = sum / 10;
            result.Add(sum % 10);
        }

        if (carry > 0) {
            result.Add(carry);
        }
        result.Reverse();
        return result;
    }
}