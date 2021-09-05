from typing import List
from math import floor

class Solution:
    def mySqrt(self, x: int) -> int:
        if x <= 1: return x
        
        l = 1
        h = x

        while l < h:
            g = (l+h)/2
            s = floor(g*g)
            if s == x: return floor(g)
            elif s > x: h = g
            elif s < x: l = g

    def search(self, nums: List[int], target: int) -> int:
        l = 0
        r = len(nums)-1
        while True:
            m = (l+r)//2
            if nums[m] == target:
                return m
            elif (r - l) <= 1:
                if nums[r] == target:
                    return r
                elif nums[l] == target:
                    return l
                return -1
            elif nums[m] > target:
                r = m
            elif nums[m] < target:
                l = m
            
