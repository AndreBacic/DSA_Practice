import heapq
from typing import List

class Solution:
    def lastStoneWeight(self, stones: List[int]) -> int:
        """ O(n log n) time, O(1) space (uses input as heap) """
        if len(stones) == 1: return stones[0]
        
        stones = [-x for x in stones] # heapq is a min heap and we need a max heap, so the values must be inverted
        heapq.heapify(stones) # O(n) time, says the Python docs
        
        while len(stones) > 1:
            y = heapq.heappop(stones)
            
            if y == stones[0]: heapq.heappop(stones)
            else:
                x = heapq.heappop(stones)
                heapq.heappush(stones, y-x)
        
        if len(stones) == 1: return -stones[0] # since the values were inverted, we need to invert the last value back
        return 0