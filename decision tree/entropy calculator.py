from typing import List
import math

class Solution:
    def calculateEntropy(self, input: List[int]) -> float:
        # return Sum from i=1 to n of (Probability(Xi) * log2(Probability(Xi)))
        if not input: return 0.0

        probs = dict()
        p = 1 / len(input)
        for i in input:
            if probs.get(i):
                probs[i] += p
                continue
            probs[i] = p
        
        s = 0.0
        for i in probs.values():
            s -= i * math.log2(i) # retrns the negative of the sum, so just minus each time.
        
        s = round(s, 5)
        if s == 0: return 0.0
        return s

s = Solution()
print(s.calculateEntropy([1, 2, 3, 2]))