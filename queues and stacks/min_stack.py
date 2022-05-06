class Node:
    def __init__(self, value, min):
        self.value = value
        self.next = None
        self.min = min

class MinStack:

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
        return v

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