
// Definition for singly-linked list.
function ListNode(val, next) {
    this.val = (val===undefined ? 0 : val)
    this.next = (next===undefined ? null : next)
}
 
/**
 * Merge two sorted linked lists and return it as a new list (head of new list is output)
 * 
 * O(n) time and O(1) space
 * @param {ListNode} list1
 * @param {ListNode} list2
 * @return {ListNode}
 */
 const mergeTwoLists = function(list1, list2) {
    if (!list1) {
        return list2
    }
    if (!list2) {
        return list1
    }
    let head = null
    if (list1.val < list2.val) {
        head = list1
        list1 = list1.next
    } else {
        head = list2 
        list2 = list2.next
    }
    let tail = head
    while (true) {        
        if (list1 === null) {
            tail.next = list2
            return head
        }
        if (list2 === null) {
            tail.next = list1
            return head
        }
        if (list1.val < list2.val) {
            tail.next = list1
            list1 = list1.next
        } else {
            tail.next = list2
            list2 = list2.next
        }
        tail = tail.next
    }
}