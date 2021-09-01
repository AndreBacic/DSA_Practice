class MyCircularQueue:

    def __init__(self, k: int):
        self._head = -1
        self._tail = -1
        self._size = k
        self._queue = []
        for i in range(k):
            self._queue.append(None)

    def enQueue(self, value: int) -> bool:
        if self.isFull():
            return False
        
        self._tail += 1
        if self._tail >= self._size:  # wrap around
            self._tail = 0
        self._queue[self._tail] = value

        if self._head < 0:
            self._head = self._tail
        return True

    def deQueue(self) -> bool:
        if self._head == -1:
            return False

        self._queue[self._head] = None

        self._head += 1
        if self._head == self._tail+1:  # empty!
            self._head = self._tail = -1

        elif self._head >= self._size:  # wrap around
            self._head = 0

        return True

    def Front(self) -> int:
        if self.isEmpty():
            return -1
        return self._queue[self._head]

    def Rear(self) -> int:
        if self.isEmpty():
            return -1
        return self._queue[self._tail]  

    def isEmpty(self) -> bool:
        if self._head == -1:
            return True
        return False        

    def isFull(self) -> bool:
        diff = self._tail - self._head 
        if diff == -1 or (diff == self._size-1  and not  self._size-1 == 0 == diff != self._tail):
            return True
        return False


# Your MyCircularQueue object will be instantiated and called as such:
# obj = MyCircularQueue(k)
# param_1 = obj.enQueue(value)
# param_2 = obj.deQueue()
# param_3 = obj.Front()
# param_4 = obj.Rear()
# param_5 = obj.isEmpty()
# param_6 = obj.isFull()