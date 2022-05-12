from typing import List

# this solution works, but doesn't memoize calculated results,
# so it has a runtime of O(2^n) (and space of O(2^n) because of the recursion call stack)
def f(l):    
    if len(l) <= 2: return l[0]
    return l[0] + min(f(l[1:]), f(l[2:]))
class Solution0:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        return min(f(cost), f(cost[1:]))

# Dynamic Programming solution
# O(n) time, O(n) space
# Beats 92.58% of python3 submissions by time and 78.37% of python3 submissions by space
class Solution:
    def minCostClimbingStairs(self, cost: List[int]) -> int:
        costs = [None] * (len(cost)-2) + cost[-2:]
        
        for i in range(len(cost)-3, -1, -1):
            costs[i] = cost[i] + min(costs[i+1], costs[i+2])
        
        return min(costs[0], costs[1])