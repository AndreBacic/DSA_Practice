from typing import List

class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        if len(nums) < 3:
            return []

        nums.sort() # O(n log(n)) time, O(1) to O(n) space
        if nums[0] > 0 or nums[-1] < 0:
            return []
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

        # O(n^2) time, O(1) space
        p1 = 0
        p2 = len(nums) - 1
        while p2 - p1 > 1:
            if p1 > 0 and nums[p1] == nums[p1-1]:
                p1 += 1
                continue

            p3 = p1 + 1
            while p3 < p2:
                if nums[p1] + nums[p2] + nums[p3] == 0:
                    output.append([nums[p1], nums[p2], nums[p3]])
                    while p3 < p2 and nums[p3] == nums[p3+1]:
                        p3 += 1
                    while p2 > p1 and nums[p2] == nums[p2-1]:
                        p2 -= 1
                    p3 += 1
                    p2 -= 1
                elif nums[p1] + nums[p2] + nums[p3] > 0:
                    p2 -= 1
                else:
                    p3 += 1
            
            if nums[p1] == 0:
                break
            
            p1 += 1
            p2 = len(nums) - 1

        return output


if __name__ == "__main__":
    sol = Solution()
    print(sol.threeSum([-1, 0, 1, 2, -1, -4]))
    print(sol.threeSum([0, 0, 0, 0]))
    print(sol.threeSum([1,2,-2,-1]))
    print(sol.threeSum([-2,0,1,1,2]))
    print(sol.threeSum([3,0,-2,-1,1,2]))
    print(sol.threeSum([-4,-2,-2,-2,0,1,2,2,2,3,3,4,4,6,6]))
    print(sol.threeSum([-1,0,1,2,-1,-4,-2,-3,3,0,4]))
    