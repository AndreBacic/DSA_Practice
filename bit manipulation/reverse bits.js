/**
 * @param {number} n - a positive integer
 * @return {number} - a positive integer
 * 
 * O(1) time, O(1) space
 */
const reverseBits = function (n) {
    let s = n.toString(2)
    s = '0'.repeat(32 - s.length) + s
    return parseInt(s.split('').reverse().join(''), 2)
}

/**
 * @param {number} n - a positive integer
 * @return {number} - a positive integer
 * O(1) time, O(1) space
 * This was the 2nd fastest solution on Leetcode. There are a number of clever ways to use many different bitwise operators.
 */
const reverseBits2 = function (n) {
    let result = 0
    for (let i = 0; i < 32; i++) {
        let bit = (n >>> i) & 1
        result = result | (bit << (31 - i))
    }
    return result >>> 0
}