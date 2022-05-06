class Node:
    """
    Node class for a linked list in a min stack
    Each node also stores the minimum value in the stack at the time the node was created
    """
    def __init__(self, value, min):
        self.value = value
        self.next = None
        self.min = min

class MinStack:
    """
    A stack that supports push, pop, top, and retrieving the minimum element in constant time.
    
    O(1) time (for all operations), O(n) space (for the linked list)

    There are, to my knowledge, three ways to implement a min stack:
    1) Use a linked list, where each node stores the minimum value in the stack at the time the node was created
    2) Use a stack array of arrays, where each sub array is [val, min_val_at_this_point]
    3) Use two stacks, one for the values and one for the min values
    """

    def __init__(self):
        """
        initialize your data structure here.
        """
        self.root = None
        self.min = 4294967296 # 2**32, larger than guaranteed max value
        
    def push(self, val: int) -> None:
        if val < self.min:
            self.min = val
        n = Node(val,self.min)
        n.next = self.root
        self.root = n

    def pop(self) -> None:
        v = self.root.value
        self.root = self.root.next
        if self.root:
            self.min = self.root.min
        else:
            self.min = 4294967296
        #return v # uncomment if you want to return the value popped

    def top(self) -> int:
        return self.root.value

    def getMin(self) -> int:
        return self.min
        


# Your MinStack object will be instantiated and called as such:
# obj = MinStack()
# obj.push(val)
# obj.pop()
# param_3 = obj.top()
# param_4 = obj.getMin()