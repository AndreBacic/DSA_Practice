from typing import List

class Solution:
    def spiralOrder(self, matrix: List[List[int]]) -> List[int]:
        up_bound = 0
        down_bound = len(matrix)-1
        left_bound = 0
        right_bound = len(matrix[0])-1
        i=j=0
        velocity_i=0
        velocity_j=1
        output =[]
        for k in range((down_bound+1)*(right_bound+1)):
            #print(i, j, velocity_i, velocity_j, " | ", up_bound,down_bound,left_bound,right_bound)
            output.append(matrix[i][j])
            i += velocity_i
            j += velocity_j
            if j > right_bound:
                j = right_bound
                i += 1
                velocity_i = 1
                velocity_j = 0
                up_bound = i
            elif i > down_bound:
                i = down_bound
                j -=1
                velocity_i = 0
                velocity_j = -1
                right_bound = j
            elif j < left_bound:
                j = left_bound
                i -= 1
                velocity_i = -1
                velocity_j = 0
                down_bound = i
            elif i < up_bound:
                i = up_bound
                j += 1
                velocity_i = 0
                velocity_j = 1
                left_bound = j
        return output


    def findDiagonalOrder(self, mat: List[List[int]]) -> List[int]:
        # if len(mat) <= 1:
        #     return mat[0]
        # elif len(mat[0]) <= 1:
        #     output =[]
        #     for item in mat:
        #         output.append(item[0])
        #     return output

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

