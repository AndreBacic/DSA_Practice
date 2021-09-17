class MyLinkedList:
    """Singley linked list"""
    def __init__(self):
        """
        Initialize your data structure here.
        """
        self.head = None
        self.length = 0

    def get(self, index: int) -> int:
        """
        Get the value of the index-th node in the linked list. If the index is invalid, return -1.
        """
        if index < 0 or index >= self.length:
            return -1

        node = self.head
        for i in range(index):
            node = node.next

        return node.val

    def addAtHead(self, val: int) -> None:
        """
        Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
        """
        new = LinkedListNode(val, self.head)
        self.head = new
        self.length += 1

    def addAtTail(self, val: int) -> None:
        """
        Append a node of value val to the last element of the linked list.
        """
        if self.length <= 0:
            self.head = LinkedListNode(val)
            self.length = 1
            return

        node = self.head
        for i in range(self.length-1):
            node = node.next
        
        new = LinkedListNode(val)
        node.next = new
        self.length += 1

    def addAtIndex(self, index: int, val: int) -> None:
        """
        Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted.
        """
        if index <= 0:
            return self.addAtHead(val)

        if index > self.length: return
        
        if index == self.length:
            return self.addAtTail(val)

        node = self.head
        for i in range(index-1):
            node = node.next
        
        new = LinkedListNode(val, node.next)
        node.next = new
        self.length += 1

    def deleteAtIndex(self, index: int) -> None:
        """
        Delete the index-th node in the linked list, if the index is valid.
        """
        if index <= 0:
            self.head = self.head.next
            self.length -= 1
            return

        if index > self.length: return
        
        node = self.head
        for i in range(index-1):
            node = node.next
        
        if node.next:
            node.next = node.next.next
            self.length -= 1
        else:
            node.next = None
        

class LinkedListNode:
    def __init__(self, val: int, next: 'LinkedListNode' = None):
        self.val = val
        self.next = next

# Your MyLinkedList object will be instantiated and called as such:
obj = MyLinkedList()
print(obj.get(1))
obj.addAtHead(2)
obj.addAtTail(7)
obj.addAtIndex(1,44)
obj.addAtTail(8)

print(obj.get(0))
print(obj.get(1))
print(obj.get(2))
obj.deleteAtIndex(0)