/**
 * @param {string} s
 * @return {boolean}
 */
 const isPalindrome = function(s) {
    // first, leave only alphanumeric characters
    s = s.replace(/[^a-zA-Z0-9]/g, '').toLowerCase()

    let l = 0, r = s.length - 1
    while (l < r) {
        if (s[l] !== s[r]) return false
        l++
        r--
    }
    return true
};