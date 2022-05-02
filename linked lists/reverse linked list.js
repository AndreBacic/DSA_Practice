/**
 * Definition for singly-linked list.
 * function ListNode(val, next) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.next = (next===undefined ? null : next)
 * }
 */
/**
 * @param {ListNode} head
 * @return {ListNode}
 * O(n) time, O(1) space
 */
 const reverseList = function(head) {
    if (head === null) {return null}
    let h = head
    let t = head.next
    head.next = null
    let n = null
    while (t !== null) {
        n = t.next
        t.next = h
        h = t
        t = n
    }
    return h
}

// more elegant solution (still O(n) time, O(1) space)
const reverseList2 = function(head) {
    let curr = head
    let prev = null
    while (curr !== null) {
        const next = curr.next
        curr.next = prev
        prev = curr
        curr = next
    }
    return prev
}