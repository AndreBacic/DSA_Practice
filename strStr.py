# TODO: Actually re-invent python's str.find() function for learning purposes?
class Solution:
    def strStr(self, haystack: str, needle: str) -> int:
        # return haystack.find(needle) # this is the old way
        return haystack.index(needle) if needle in haystack else -1 # clever Copilot solution
        # instead of being productive, re-invent python's str.find() function for learning purposes: