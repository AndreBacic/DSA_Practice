from typing import List

class Solution:
    def rob(self, nums: List[int]) -> int:
        """ O(n) time, O(1) space """
        a, b = 0, 0
        for n in nums:
            a, b = b, max(a+n, b)
        return b
