/**
 * @param {number[][]} matrix
 * @return {void} Does not return anything, but modifies matrix in-place instead.
 */
 const rotate = function(matrix) {
    let l = matrix.length-1
    for (let i = 0; i < Math.floor((l+1)/2); i++) {
        for (let j = 0; j < Math.ceil((l+1)/2); j++) {
            let x = l-i, y = l-j
            let t = matrix[i][j]
            matrix[i][j] = matrix[y][i]
            matrix[y][i] = matrix[x][y]
            matrix[x][y] = matrix[j][x]
            matrix[j][x] = t            
        }
    }
}

/**
 * @param {number[][]} matrix
 * @return {void} Does not return anything, but modifies matrix in-place instead.
 */
function rotate2(m) {
    let l = m.length
    //transpose (flip across i=j diagonal axis)
    for (let i = 1; i<l; i++) {
        for (let j = 0; j < i; j++) {
            [m[i][j], m[j][i]] = [m[j][i], m[i][j]]
        }
    }    
    //reflect (reverse)
    for (let i = 0; i<l; i++) {
        for (let j = 0; j < Math.floor(l/2); j++) {
            [m[i][j], m[i][l-j-1]] = [m[i][l-j-1], m[i][j]]
        }
    }    
}
