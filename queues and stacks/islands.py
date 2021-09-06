from typing import List


class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        queue = [[0, 0]]
        visited = []
        islandCount = 0
        for i in range(len(grid)):
            for j in range(len(grid[0])):
                if [i, j] in visited:
                    continue
                elif grid[i][j] == "1":
                    self.addIsland(i, j, queue, visited, grid)
                    islandCount += 1
        return islandCount

    def addIsland(self, i: int, j: int, queue: List[List[int]], visited: List[List[int]], grid: List[List[str]]):
        visited.append([i, j])
        for move in [(-1, 0), (0, 1), (1, 0), (0, -1)]:
            a = i + move[0]
            b = j + move[1]
            if a < 0 or b < 0 or a >= len(grid) or b >= len(grid[0]) or [a, b] in visited:
                continue
            elif grid[a][b] == "1":
                self.addIsland(a, b, queue, visited, grid)

