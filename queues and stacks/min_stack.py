class MinStack:

    def __init__(self):
        """
        initialize your data structure here.
        """
        self._stack = []
        

    def push(self, val: int) -> None:
        self._stack.append(val)

    def pop(self) -> None:
        self._stack.pop()

    def top(self) -> int:
        return self._stack[-1]

    def getMin(self) -> int:
        if not self._stack:
            return 0

        low = self._stack[0]
        if len(self._stack) == 1:
            return low
        
        for i in self._stack[1:]:
            if i < low:
                low = i
        return low