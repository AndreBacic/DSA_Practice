import json
from typing import List
import time

class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        """
        Destroys the grid but tallies quickly

        O(n) time, where n is grid.length * grid[0].length (worst case is 2n, where every cell is a 1 and gets visited twice)
        O(n) space (recursion stack)
        """
        islandCount = 0
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if grid[i][j] == "1":
                    self.addIslandAndDestroy(i, j, grid)
                    islandCount += 1
        return islandCount

    def addIslandAndDestroy(self, i, j, grid):
        grid[i][j] = "0"
        for move in [(-1, 0), (0, 1), (1, 0), (0, -1)]:
            a = i + move[0]
            b = j + move[1]
            if a < 0 or b < 0 or a >= len(grid) or b >= len(grid[0]) or grid[a][b] == "0":
                continue
            self.addIslandAndDestroy(a, b, grid)

    # I think a faster non-destructive solution is to just make a copy of the grid and then mess up the copy
    def numIslandsNotDestructive(self, grid: List[List[str]]) -> int:
        """
        This function doesn't handle large data sets well.
        """
        visited = []
        islandCount = 0
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if grid[i][j] == "0" or [i, j] in visited:
                    continue
                elif grid[i][j] == "1":
                    self.addIsland(i, j, visited, grid)
                    islandCount += 1
        return islandCount

    def addIsland(self, i: int, j: int, visited: List[List[int]], grid: List[List[str]]):
        visited.append([i, j])
        for move in [(-1, 0), (0, 1), (1, 0), (0, -1)]:
            a = i + move[0]
            b = j + move[1]
            if a < 0 or b < 0 or a >= len(grid) or b >= len(grid[0]) or grid[a][b] == "0" or [a, b] in visited:
                continue
            elif grid[a][b] == "1":
                self.addIsland(a, b, visited, grid)

s = Solution()

grid = []
# because the vs code runner runs from the repo root, we have to access the file from the root
with open("queues and stacks/island_grid.json") as f: 
    grid = json.load(f)

    
t = time.perf_counter_ns()
answer1 = s.numIslandsNotDestructive(grid)
runtime1 = time.perf_counter_ns() - t

print(f"Answer: {answer1} \t(Non-destructive algorithm)")
print(f"Runtime: {runtime1} nanoseconds")
print(f"Runtime: {runtime1/1000000000} seconds")

t = time.perf_counter_ns()
answer = s.numIslands(grid)
runtime = time.perf_counter_ns() - t

print(f"Answer: {answer} \t(Speedy, destructive algorithm)")
print(f"Runtime: {runtime} nanoseconds")
print(f"Runtime: {runtime/1000000000} seconds")

############# Output: #############
# Answer: 109     (Non-destructive algorithm)
# Runtime: 31925899000 nanoseconds
# Runtime: 31.925899 seconds
# Answer: 109     (Speedy, destructive algorithm)
# Runtime: 117380000 nanoseconds
# Runtime: 0.11738 seconds
