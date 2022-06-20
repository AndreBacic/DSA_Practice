/**
 * @param {number[][]} grid
 * @return {number}
 * O(m*n) time, O(m*n) max space
 * 
 * Note that the recursive version of this solution has the same complexity, but apparently runs faster.
 */
const maxAreaOfIsland = function (grid) {
    let m = grid.length - 1, n = grid[0].length - 1, l = 0
    for (let i = 0; i <= m; i++) {
        for (let j = 0; j <= n; j++) {
            if (grid[i][j] !== 1) continue

            let t = 0
            const s = [[i, j]]

            while (s.length > 0) {
                c = s.pop()
                if (grid[c[0]][c[1]] === 1) t++
                grid[c[0]][c[1]] = 0

                if (c[0] > 0 && grid[c[0] - 1][c[1]] === 1) s.push([c[0] - 1, c[1]])
                if (c[0] < m && grid[c[0] + 1][c[1]] === 1) s.push([c[0] + 1, c[1]])
                if (c[1] > 0 && grid[c[0]][c[1] - 1] === 1) s.push([c[0], c[1] - 1])
                if (c[1] < n && grid[c[0]][c[1] + 1] === 1) s.push([c[0], c[1] + 1])
            }
            l = Math.max(l, t)
        }
    }
    return l
}