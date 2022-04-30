from typing import List

class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        if len(nums) < 3:
            return []

        nums.sort() # O(n log(n)) time, O(1) to O(n) space
        output = []

        def binary_search(target, i,j):
            # O(log(n)) time, O(1) space
            while i <= j:
                mid = (i + j) // 2
                if nums[mid] == target:
                    return True
                elif nums[mid] > target:
                    j = mid - 1
                else:
                    i = mid + 1
            return False

        def f(i, j):
            missing = -(nums[i] + nums[j])
            if binary_search(missing, i+1, j-1):
                new_triplet = [nums[i], missing, nums[j]]
                if len(output) == 0 or output[-1] != new_triplet:
                    output.append(new_triplet)
            return missing

        # O(n^2) time, O(1) space
        p1 = 0
        p2 = len(nums) - 1
        while p2 - p1 > 1:
            missing = f(p1, p2)

            if missing < 0:
                p2 -= 1
            elif missing > 0:
                p1 += 1
            else: # missing == 0
                if nums[p1+1] == nums[p1]:
                    p1 += 1
                elif nums[p2-1] == nums[p2]:
                    p2 -= 1
                else:
                    # we've got to check both options, p1+1 and p2-1 before moving both pointers
                    f(p1, p2-1)
                    f(p1+1, p2)

                    p1 += 1
                    p2 -= 1

        return output


if __name__ == "__main__":
    sol = Solution()
    print(sol.threeSum([-1, 0, 1, 2, -1, -4]))
    print(sol.threeSum([0, 0, 0, 0]))
    print(sol.threeSum([1,2,-2,-1]))
    print(sol.threeSum([-2,0,1,1,2]))
    print(sol.threeSum([-4,-2,-2,-2,0,1,2,2,2,3,3,4,4,6,6]))
    print(sol.threeSum([-1,0,1,2,-1,-4,-2,-3,3,0,4]))