from typing import List
import time
class Solution:
    def openLock(self, deadends: List[str], target: str) -> int:
        if "0000" in deadends:
            return -1
        elif target == "0000": return 0

        deadends_dict = {}
        for end in deadends:
            deadends_dict[end] = True
        
        queue = ["0000"]
        visited = {"0000":True}
        step = -1

        while (len(queue) > 0):
            step += 1
            size = len(queue)
            for i in range(size):
                current = queue.pop(0)
                if current == target:
                    return step
                for i in range(4):
                    for b in [True, False]:
                        newCombo = self.turnLock(current, i, b)
                        if deadends_dict.get(newCombo) == None and visited.get(newCombo) == None:
                            queue.append(newCombo)
                            visited[newCombo] = True
                
        return -1

    def turnLock(self, currentCombo: str, pos: int, forward: bool = True) -> str:
        s = int(currentCombo[pos])
        if forward:
            s = (s + 1)%10
        else:
            s = (s - 1)%10
        return currentCombo[0:pos]+ str(s) + currentCombo[pos+1:]


    def openLockWithBFS(self, deadends: List[str], target: str) -> int:
        """
        Slow as molasses because it has to search through a couple of huge lists a bajillion times.
        """
        if "0000" in deadends:
            return -1
        queue = ["0000"]
        visited = ["0000"]
        step = -1

        while (len(queue) > 0):
            step += 1
            size = len(queue)
            for i in range(size):
                current = queue.pop(0)
                if current == target:
                    return step
                for i in range(4):
                    for b in [True, False]:
                        newCombo = self.turnLock(current, i, b)
                        if newCombo not in deadends and newCombo not in visited:
                            queue.append(newCombo)
                            visited.append(newCombo)
                
        return -1    
    


s = Solution()
t = time.time()
print(s.openLock(["5557","5553","5575","5535","5755","5355","7555","3555","6655","6455","4655","4455","5665","5445","5645","5465","5566","5544","5564","5546","6565","4545","6545","4565","5656","5454","5654","5456","6556","4554","4556","6554"], "5555"))
print(time.time()-t)