/*
 * You are climbing a stair case. It takes n steps to reach the top.
 * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
 *
 * Answer... is the same as the fibonacci sequence!
 * Why? Because for any n stairs, the number of distinct ways
 * is all the ways from n-1 stairs + 1 step,
 * plus all the ways from n-2 stairs + 2 steps.
 * Because you add 1 step to the n-1 stairs solution, and 2 steps to the n-2 stairs solution,
 * All of those new solutions are distinct.
 * 
 * To implement this, we can use recursion and a cache of previously calculated results.
 * O(n) time and O(n) space (the cache will store n results).
 */
const cache = [1,1,2] // because 0 stairs doesn't make sense, I'll start the cache with the 1 and 2 stairs solutions.
/**
 * @param {number} n
 * @return {number}
 */
const climbStairs0 = function(n) {
    if (cache[n] === undefined) cache[n] = climbStairs(n-1) + climbStairs(n-2);
    return cache[n]    
}

// Better performance with for loop and object (hash table)
const climbStairs = function(n) {
    const cache = {
        1: 1,
        2: 2
    }
    for (let i = 3; i <= n; i++) { // start at 3 because we already have 1 and 2 stairs solutions
        cache[i] = cache[i-1] + cache[i-2]
    }
    return cache[n]
}