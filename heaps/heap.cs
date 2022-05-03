using System;
using System.Collections.Generic;

/// <summary>
/// Implementation of a min heap
/// Uses a List to store the binary tree, which makes easy to find parent and children indices
/// The formulas for finding parent and children indices are slightly weird because 
///     this implementation uses the 0th index as the root instead of the 1st index
/// </summary>
public class MinHeap {
    private List<int> nums = new List<int>();
    public void Add(int val) {
        nums.Add(val);
        int i = nums.Count - 1;
        while (i >= 0 && nums[i] < nums[Parent(i)]) {
            Swap(i, Parent(i));
            i = Parent(i);
        }
        
    }
    public int Pop() {
        int output = nums[0];
        nums[0] = nums[nums.Count - 1];
        nums.RemoveAt(nums.Count - 1);
        int i = 0;
        while (IsLeaf(i) == false) {
            int child = LeftChild(i);
            if (child < nums.Count - 1 && nums[child] > nums[child + 1]) {
                child++;
            }
            if (nums[i] <= nums[child]) {
                break;
            }
            Swap(i, child);
            i = child;
        }
        
        return output;
    }
    public int Peek() {
        if (nums.Count == 0) {
            return 0;
        }
        return nums[0];
    }
    public int Size() {
        return nums.Count;
    }
    private int Parent(int i) {
        return (i-1)/2;
    }
    private int LeftChild(int i) {
        return 2*i + 1;
    }
    private int RightChild(int i) {
        return 2*i + 2;
    }
    private bool IsLeaf(int i) {
        return LeftChild(i) > nums.Count - 1;
    }
    private void Swap(int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }    
}
class Program {
    static void Main(string[] args) {
        var heap = new MinHeap();
        Console.WriteLine(heap.Peek());
        heap.Add(5);
        heap.Add(13);
        heap.Add(1);
        heap.Add(12);
        heap.Add(4);
        heap.Add(-4);
        heap.Add(9);
        heap.Add(7);
        heap.Add(17);
        heap.Add(-8);
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
        Console.WriteLine(heap.Pop());
    }
}
