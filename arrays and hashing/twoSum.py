from typing import List

class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        """ 
        Given an array of integers, return indices of the two numbers such that they add up to a specific target.        
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        
        O(n) time, O(n) space
        """
        # 1) iterate through nums and make a hashtable of it's values (key=value;value=index)
        # 2) iterate through again, but see if target-nums[i] in hashtable keys and value != i (different indices, because you can't use 1 number twice)
        #if not nums: return [] # uncomment if empty lists are given
        #if len(nums) == 1: # uncomment if this case can happen
        #    if nums[0] == target: return [0]
        #    return []
        d = {}
        for i in range(len(nums)):
            if d.get(nums[i]): continue
            d[nums[i]] = i
        
        for i in range(len(nums)):
            n = target - nums[i]
            v = d.get(n)
            if v and v != i:
                return [i, v]
        
        return [] # no numbers sum to target
    
    def twoSumBetter(self, nums: List[int], target: int) -> List[int]:
        d = {}
        for i in range(len(nums)):
            n = target - nums[i]
            if d.get(n):
                return [d[n], i]
            d[nums[i]] = i
        
        return [] # no numbers sum to target