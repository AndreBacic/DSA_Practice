using System.Linq;
public class Solution {
    public int[] PlusOne(int[] digits) {
        // loop through digits
        // if digit is 9, set to 0 and carry = 1
        // else, increment digit and break
        // if the last digit (well first because that's the largest) is 9, set it to zero and append a 1 to the front
        // return the array (duh)
        for (int i = digits.Length - 1; i >= 0; i--) {
            if (digits[i] == 9) {
                digits[i] = 0;
                if (i == 0) {
                    int[] newDigits = {1};
                    int[] result = newDigits.Concat(digits).ToArray();
                    return result;
                }
            } else {
                digits[i]++;
                break;
            }
        }

        return digits;
    }
}