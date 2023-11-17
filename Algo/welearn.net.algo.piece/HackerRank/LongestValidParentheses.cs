namespace welearn.net.algo.piece.HackerRank; 

public static class LongestValidParentheses {
    public static int Find(string s) {
        var i = 0;
        var stack = new Stack<int>();
        var connects = Enumerable.Repeat(-1, s.Length).ToArray();
        var maxPair = (from: -1, to: -1);
        var lastPairIndex = -1;
        foreach (var c in s) {
            if (c == '(') {
                stack.Push(i);
                if (lastPairIndex >= 0) connects[i] = lastPairIndex;
                lastPairIndex = -1;
            }
            else {
                if (stack.TryPop(out var index)) {
                    var validPair = (from: index, to: i);
                    // connect with previous valid pair
                    // get connection
                    var iFriend = connects[index];
                    if (iFriend >= 0) {
                        validPair.from = iFriend;
                    }
                    
                    // compare with max
                    if (validPair.to - validPair.from > maxPair.to - maxPair.from) {
                        maxPair = validPair;
                    }

                    lastPairIndex = validPair.from;
                }
                else {// invalid close
                    lastPairIndex = -1;
                }
            }

            ++i;
        }

        return maxPair.to == maxPair.from ? 0 : maxPair.to - maxPair.from + 1;
    }
    
    // good way
    public static int Find2(string s)
    {
        var max = 0;
        // Stack may contain two types of positions:
        // 1. open parenthese `(` positions, their values are not used, they maintain the correct stack state
        // 2. closed parenthese `)` position used for calculation of the following `possibly valid` parentheses sequence length (if initial `-1` position is gone)
        var stack = new Stack<int>();
        stack.Push(-1); // Initial position used for calculation of the following `possibly valid` parentheses sequence length

        for (var i=0; i<s.Length; i++)
        {
            if (s[i] == '(') stack.Push(i);
            else    // `)`
            {
                stack.Pop();

                if (stack.Count == 0) stack.Push(i);  // Parentheses were INVALID, put the current position `i` to the stack (as a start position for potentially valid parentheses going forward)
                else max = Math.Max(max, i - stack.Peek()); // Parentheses were VALID, so update the MAX with their length: `endPos - startPos`
            }
        }

        return max;
    }
}