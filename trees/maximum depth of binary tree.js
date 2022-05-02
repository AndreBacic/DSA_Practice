/**
 * Definition for a binary tree node.
 * function TreeNode(val, left, right) {
 *     this.val = (val===undefined ? 0 : val)
 *     this.left = (left===undefined ? null : left)
 *     this.right = (right===undefined ? null : right)
 * }
 */
/**
 * @param {TreeNode} root
 * @return {number}
 * O(n) time and O(n) space (space is for the recursion stack)
 */
 const maxDepth = function(root) {
    if (root === null) {
        return 0
    }
    return 1 + Math.max(maxDepth(root.left), maxDepth(root.right))
};