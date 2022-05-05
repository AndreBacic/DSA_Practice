// Runtime: 65 ms, faster than 99.17% of JavaScript online submissions for Valid Anagram.
// Memory Usage: 44.3 MB, less than 52.04% of JavaScript online submissions for Valid Anagram.

/**
 * @param {string} s
 * @param {string} t
 * @return {boolean}
 * O(n) time, O(n) space
 */
 const isAnagram = function(s, t) {
    // algo 1: take 1st letter and delete in both, if missing FALSE, if "" TRUE
    //  ^ O(n^2) worst case, O(n) best, O(n^2) average
    
    // algo 2 & 3: use str[26], one index per letter, to simulate a hash table
    // or use a hash table (unicode-friendly)
    // iterate through s and make letter:count pairs
    // algo 2: iterate through t and decrement count per letter in hash table, FALSE if count exceeded or not met
    // algo 3: iterate through t and make letter:count pairs, then compare keys and then key values
    
    // here's algo 2
    //s = s.replace(/[^a-zA-Z0-9]/g, '').toLowerCase() // uncomment if whitespace is included
    //t = t.replace(/[^a-zA-Z0-9]/g, '').toLowerCase()
    if (s.length !== t.length) return false;
    
    hash = {}
    for (let c of s) {
        if (!hash[c]) {
            hash[c] = 1
        }
        else {hash[c]++}
    }
    for (let c of t) {
        if (!hash[c]) return false;
        hash[c]--
        if (hash[c] < 0) return false;
    }
    return true // same length strings so if we're here they have the same count of the same letters
};