/**
 * Determines if target is in 2d array of integers matrix
 * First searches by row, then by column to be more efficient
 * O(log(m) + log(n)) time, where m is the number of rows and n is the number of columns
 * O(1) space
 * @param {number[][]} matrix
 * @param {number} target
 * @return {boolean}
 */
const searchMatrix = function(matrix, target) {
    if (!matrix || !matrix[0]) return false
    
    let l = 0, r = matrix.length - 1
    let n = matrix[0].length - 1
    let c = matrix[0]
    while (l <= r) {
        let m = Math.floor((l+r)/2)
        if (matrix[m][0] <= target && target <= matrix[m][n]) {
            c = matrix[m]
            break
        }
        else if (target < matrix[m][0]) r = m-1
        else l = m+1
    }

    l = 0, r = n
    while (l <= r) {
        let m = Math.floor((l+r)/2)
        if (c[m] === target) return true
        else if (c[m] < target) l = m+1
        else r = m-1
    }
    return false
}


/**
 * Determines if target is in 2d array of integers matrix
 * O(log (m*n)) time, where m is the number of rows and n is the number of columns
 * O(1) space
 * @param {number[][]} matrix
 * @param {number} target
 * @return {boolean}
 */
const searchMatrix0 = function(matrix, target) {
    if (!matrix || !matrix[0]) return false
    let l = 0
    let r = matrix.length * matrix[0].length -1
    while (l <= r) {
        let m = Math.floor((l+r)/2)
        let i = Math.floor(m / matrix[0].length)
        let j = m % matrix[0].length
        if (matrix[i][j] === target) return true
        else if (target < matrix[i][j]) r = m-1
        else l = m+1
    }
    return false
}