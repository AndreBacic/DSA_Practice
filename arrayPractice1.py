from typing import List

class Solution:
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
    