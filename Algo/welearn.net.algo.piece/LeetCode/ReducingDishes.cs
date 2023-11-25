namespace welearn.net.algo.piece.LeetCode; 

//https://leetcode.com/problems/reducing-dishes/description/
public class ReducingDishes {
    public int MaxSatisfaction(int[] satisfaction) {
        Array.Sort(satisfaction);
        var sum = int.MinValue;
        int max;

        var skip = 0;
        do {
            max = sum;
            sum = 0;
            for (var i = skip; i < satisfaction.Length; ++i) {
                sum += (i - skip + 1) * satisfaction[i];
            }

            ++skip;
        } while (sum > max);
        
        return max;
    }
    
    // after refer solution
    public int MaxSatisfaction2(int[] satisfaction) {
        // order by descending
        Array.Sort(satisfaction, (i1, i2) => i2 - i1);
        int sum = 0, sumTotal = 0;
        
        foreach (var e in satisfaction) {
            sum += e;
            if (sum <= 0) break;
            sumTotal += sum;
        }

        return sumTotal;
    }
}