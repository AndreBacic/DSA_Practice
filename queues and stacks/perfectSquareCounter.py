import math
import time
class Solution:
    def numSquares(self, n: int) -> int:
        queue = [n] # queue of remainders
        step = 0
        while (len(queue) > 0):
            step += 1
            size = len(queue)
            #print(step, "  ####  ", queue)
            for i in range(size):
                current = queue.pop(0)
                if current == 2 or current == 3:
                    queue.append(current-1)

                s = math.ceil(math.sqrt(current))
                if current == 1 or s*s == current:
                    return step

                for n in range(math.ceil(s/2), s):
                    queue.append(current-n*n)
                
        return step # the code should never get here but just in case


s = Solution()
tg = time.time()
d = []
for i in range(1, 10000):
    t = time.time()
    n = s.numSquares(i)
    t1 = time.time()-t
    d.append([i, n, t1])

print(time.time()-tg)
for l in d:
    if l[1] > 4 or l[2] > 0.1:
        print(l)
