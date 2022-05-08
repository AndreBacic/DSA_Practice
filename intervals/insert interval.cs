public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if (intervals.Length == 0) return new int[1][] { newInterval };
        // because removing array items is O(n), that is the best time complexity we can get
        List<int[]> output = new List<int[]>();
        bool addedNew = false;
        // loop through intervals
        for (int i = 0; i < intervals.Length; i++) {
            // case 0: new is outside i, and after it
            // case 1: new is outside i, but before it
            // case 2: new overlaps with i on the right (new is ahead)
            // case 3: new overlaps with i on the left (new is behind)
            // case 4: new is inside or equal to i
            if (intervals[i][1] < newInterval[0]) { // after i
                output.Add(intervals[i]);
                if (i == intervals.Length - 1) {
                    output.Add(newInterval);
                }
            } else if (newInterval[1] < intervals[i][0]) { // before i
                if (!addedNew) {
                    output.Add(newInterval);
                    addedNew = true;
                }
                output.Add(intervals[i]);
                
            } else if (newInterval[0] <= intervals[i][1]) { // overlaps right or inside or equal to
                int[] r = new int[2] {Math.Min(newInterval[0], intervals[i][0]), newInterval[1]};
                // loop until
                // 1: new[1] < i[0]
                // 2: new[1] <= i[1]
                // 3: end of intervals (new[1] > i[1])
                for (; i < intervals.Length; i++) {
                    if (newInterval[1] < intervals[i][0]){
                        i--; // so i gets added to output next outer loop iteration
                        break;
                    } else if (newInterval[1] <= intervals[i][1]) {
                        r[1] = intervals[i][1];
                        break;
                    }
                }
                output.Add(r);
                addedNew = true;
            }
            else { // overlaps left
                output.Add(new int[2] {newInterval[0], intervals[i][1]});
                addedNew = true;
            }
        }
        
        return output.ToArray();
    }
}