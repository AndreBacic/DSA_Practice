from typing import List

class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        if digits[len(digits)-1] >= 9:
            return self.carryOverNum(len(digits)-1, digits)
        digits[len(digits)-1] += 1
        return digits

    def carryOverNum(self, i: int, digits: List[int]) -> List[int]:
        if i < 0:
            digits = [1]+digits
        elif digits[i] >= 9:
            digits[i] = 0
            digits = self.carryOverNum(i-1, digits)
        else:
            digits[i] += 1
        return digits


    def dominantIndex(self, nums: List[int]) -> int:
        if len(nums) == 1:
            return 0
        largest = -1
        s_largest = -1
        index = -1
        for i, v in enumerate(nums):
            if v > largest:
                s_largest = largest
                largest = v
                index = i
            elif v > s_largest:
                s_largest = v

        if largest >= s_largest*2:
            return index
        return -1

    def pivotIndex(self, nums: List[int]) -> int:
        output = -1

        for i in range(len(nums)):
            sumLeft = sum(nums[0 : i])
            sumRight = sum(nums[i+1 : len(nums)])
            if sumLeft == sumRight:
                output = i
                break
            #print(i, sumLeft, sumRight)

        return output
    