from typing import List

class Solution:
    def findDiagonalOrder(self, mat: List[List[int]]) -> List[int]:
        if len(mat) <= 1:
            return mat[0]
        elif len(mat[0]) <= 1:
            output =[]
            for item in mat:
                output.append(item[0])
            return output

        output = []
        i, j = 0, 0
        direction = 1
        for k in range(len(mat)*len(mat[0])):
            output.append(mat[i][j])
            i -= direction
            j += direction
            if i >= len(mat):
                i = len(mat)-1
                direction = -direction
                j += 2
                continue
            if j >= len(mat[0]):
                j = len(mat[0])-1
                i += 2
                direction = -direction
                continue
            if i < 0:
                i = 0
                direction = -direction
            elif j < 0:
                j = 0
                direction = -direction

        return output

