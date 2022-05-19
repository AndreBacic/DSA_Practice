/**
 * Counts the number of 1 bits in a given 32-bit integer. (supposedly unsigned)
 * 
 * O(1) time, O(1) space (n is always 32 bits long)
 * Well, it's really O(<=32) time and space, because for smaller numbers the binary representation is NOT padded with zeros.
 * Beats 95.24% of LeetCode JavaScript submissions by time :D
 * @param {number} n - a positive integer
 * @return {number}
 */
const hammingWeight = function (n) {
    s = (n >>> 0).toString(2)
    o = 0
    for (let c of s) {
        o += c === '1'
    }
    return o
}