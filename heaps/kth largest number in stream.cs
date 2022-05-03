
/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */
public class KthLargest {
    private MinHeap heap = new MinHeap();
    private int k;

    public KthLargest(int k, int[] nums) {
        this.k = k;
        foreach (int i in nums) {
            heap.Add(i);
        }
        while (heap.Size() > k) {
            heap.Pop();
        }
    }
    
    public int Add(int val) {
        if (val < heap.Peek() && heap.Size() >= k) {
            return heap.Peek();
        }
        heap.Add(val);
        if (heap.Size() > k) {
            heap.Pop();    
        }        
        return heap.Peek();
    }
}

/// <summary>
/// Even though LeetCode condemns this approach as 'naive,' it beat 88% of submissions by speed.
/// </summary>
public class KthLargestNaiveApproach {
    private int k;
    private List<int> nums;

    public KthLargestNaiveApproach(int k, int[] nums) {
        this.k = k;
        Array.Sort(nums); // O(n log n) time
        this.nums = nums.ToList();
    }
    // O(log n) time to find insertion index + O(n) time it takes to Insert an item into a List = O(n) time
    // O(1) space (except that the space is stored in the List)
    public int Add(int val) {
        int l = 0;
        int r = nums.Count-1;
        while (l <= r) {
            int m = (l+r)/2;
            if (nums[m] == val) {
                l = m;
                break;
            }
            else if (val < nums[m]) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }
        nums.Insert(l, val);
        
        return nums[nums.Count - k]; // min of k is 1
    }
}