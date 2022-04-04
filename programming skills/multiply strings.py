class Solution:
    def multiply(self, num1: str, num2: str) -> str:
        """
        Multiply two strings of digits.
        num1 and num2 are non-negative integers.
        """
        if num1 == '0' or num2 == '0':
            return '0'

        if num1 == '1':
            return num2
        if num2 == '1':
            return num1

        num1 = num1[::-1] # reverse nums so that we can loop through it from the beginning
        num2 = num2[::-1]

        layers = []
        for n2 in num2:
            layer = ""
            carry_over = 0
            for n1 in num1:
                result = str(int(n1) * int(n2) + carry_over)
                if len(result) > 1:
                    carry_over = int(result[0])
                    result = result[1:]
                else:
                    carry_over = 0
                layer += result
            if carry_over > 0:
                layer += str(carry_over)

            layers.append(layer)
        
        # for s in layers:
        #     print(s)

        # note that at this point all of the layers are backwards

        answer  = ""
        i = 0
        carry_over = 0
        while i < len(layers)+len(layers[-1]):
            j = 0
            d = 0
            for layer in layers:
                if len(layer) <= i-j:
                    j += 1
                    continue
                if i-j < 0:
                    break
                d += int(layer[i-j])
                j += 1
            
            d += carry_over
            carry_over = 0
            if d > 9:
                carry_over = int(str(d)[:-1])
                d = int(str(d)[-1])
            
            answer += str(d)
            i += 1
        
        answer = answer[::-1]

        if answer[0] == '0':
            answer = answer[1:]

        return answer

s = Solution()
print(s.multiply("123", "456"))
