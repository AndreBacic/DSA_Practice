public class Solution {
    public string AddBinary(string a, string b) {
        string answer = "";
        int carry = 0;
        int j = a.Length>b.Length ? a.Length : b.Length;
        for (int i = 0; i < j; i++) {
            int ai = a.Length - 1 - i;
            int bi = b.Length - 1 - i;
            int sum = carry;
            if (ai >= 0) sum += a[ai] - '0';
            if (bi >= 0) sum += b[bi] - '0';
            carry = sum / 2;
            answer = (sum % 2) + answer;
        }
        if (carry > 0) answer = "1" + answer;

        return answer;
    }
}