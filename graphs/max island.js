/**
 * @param {number[][]} grid
 * @return {number}
 */
const maxAreaOfIsland = function (grid) {
    // m*n time, m*n max space
    // traverse until a 1 is found
    // total++; add all neighbor 1's to stack; change current to 0
    // repeat until no neighbors; largest = total; total = 0
    // repeat last 3 until end of grid
    let m = grid.length, n = grid[0].length, l = 0
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (grid[i][j] !== 1) continue

            let t = 0
            const s = [[i, j]]

            while (s.length > 0) {
                t++
                c = s.pop()
                grid[c[0]][c[1]] = 0

                if (c[0] > 0 && grid[c[0] - 1][c[1]] === 1) s.push([c[0] - 1, c[1]])
            }

        }
    }
    return l
}