import heapq
from types import List


class Solution:
    def topKFrequent(self, nums: List[int], k: int) -> List[int]:
        """
        Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

        O(kn log n) time, O(n+k) space, where n = len(nums)
        """
        d = {}
        for n in nums:
            if not d.get(n):
                d[n] = 1
            else:
                d[n] += 1

        # TODO: Actually implement a sorting algorithm
        return heapq.nlargest(k, d, lambda i : d[i])
    
    def topKFrequentAsImplementedByNeetCode(self, nums: List[int], k: int) -> List[int]:
        """
        O(n) time and space
        """
        count = {}
        freq = [[] for i in range(len(nums) + 1)] # this is the magic sauce. there is an array for each tally. So, if there are 3 '5's in nums, freq[3] will have 5 appended to it. Then, we loop from the end of freq (the most frequent elements) and grab the first k items, skipping over all the empty arrays in freq.

        for n in nums:
            count[n] = 1 + count.get(n, 0)
        for n, c in count.items():
            freq[c].append(n)

        res = []
        for i in range(len(freq) - 1, 0, -1):
            for n in freq[i]:
                res.append(n)
                if len(res) == k:
                    return res