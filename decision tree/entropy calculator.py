from typing import List
import math

class Solution:
    def calculateMaxInfoGain(self, petal_length: List[float], species: List[str]) -> float:
        if not (petal_length and species) or len(petal_length) != len(species): return 0

        max_info_gain = 0
        H = self.calculateEntropy(species)
        l = len(species)
        for i in petal_length:
            l1 = [] # todo: refactor to just move the current item from l2 to l1 instead of remaking the lists. (edit: I did this in another file and have left this code this way for now)
            l2 = []
            for j, s in enumerate(species):
                if petal_length[j] <= i:
                    l1.append(s)
                else:
                    l2.append(s)

            H1 = self.calculateEntropy(l1) * len(l1) / l
            H2 = self.calculateEntropy(l2) * len(l2) / l
            gain = H - H1 - H2
            if gain > max_info_gain:
                max_info_gain = gain
        
        return max_info_gain


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
            s -= i * math.log2(i) # returns the negative of the sum, so just minus each time.
        
        s = round(s, 5)
        if s == 0: return 0.0 # -0.0 otherwise, which LeetCode doesn't honor.
        return s

s = Solution()
print(s.calculateEntropy([1, 2, 3, 2]))