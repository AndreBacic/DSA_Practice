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
}

const maxDepthBFS = function(root) { // BFS = Breadth First Search
    if (root === null) {
        return 0
    }
    let queue = [root]
    let depth = 0
    while (queue.length > 0) {
        let size = queue.length
        depth++
        for (let i = 0; i < size; i++) {
            let node = queue.shift()
            if (node.left !== null) {
                queue.push(node.left)
            }
            if (node.right !== null) {
                queue.push(node.right)
            }
        }
    }
    return depth
}

const maxDepthDFS = function(root) { // DFS = Depth First Search
    if (root === null) {
        return 0
    }
    let stack = [[root, 1]]
    let result = 1
    while (stack.length > 0) {
        let [node, depth] = stack.pop()
        result = Math.max(result, depth)
        if (node.left !== null) {
            stack.push([node.left, depth + 1])
        }  
        if (node.right !== null) {
            stack.push([node.right, depth + 1])
        }
    }
    return result
}