from typing import List


class Solution:
    def isMonotonic(self, nums: List[int]) -> bool:
        if len(nums) <= 2:
            return True
        
        mode = "unsure" # "increasing" or "decreasing" or "unsure"

        for i in range(1, len(nums)):
            if nums[i] > nums[i-1]:
                if mode == "decreasing":
                    return False
                mode = "increasing"
            elif nums[i] < nums[i-1]:
                if mode == "increasing":
                    return False
                mode = "decreasing"

        return True 