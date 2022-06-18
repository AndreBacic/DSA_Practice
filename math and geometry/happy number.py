class Solution:
    # Beats 89.83% of submissions by time
    def isHappy(self, n: int) -> bool:
        d = dict()
        while True:
            if n == 1: return True
            if d.get(n): return False
            d[n] = True
            s = str(n)
            n = 0
            for c in s:
                n += (int(c)**2)
    
    # I copied this solution from the internet, and while it is shorter in code it takes longer to run
    def isHappyV2(self, n: int) -> bool:
        while n not in [1, 4]: # n will either end up as 1 or 4. After some testing, I think the iterations usually hit 37 before they hit 4.
            n = sum(int(d)**2 for d in str(n))
        return n==1

    # note that someone made an 18ms solution (my best was 36ms) that just performs 6 iterations, 
    # and if n is not a happy number by that point it will return False.