namespace welearn.net.algo.piece.LeetCode;

public static class AtomCounter {
    public static string NumberOfAtom(string chemicalFormula) {
        var lastChar = '\0';
        var curElement = string.Empty;
        var curNumber = 0;
        var rootMapElement = new Dictionary<string, int>();
        var mapElement = rootMapElement;
        var stackMap = new Stack<Dictionary<string, int>>([rootMapElement]);

        foreach (var c in chemicalFormula + "\0") {
            if (lastChar == ')' && !IsNumber(c, out _))
                curNumber = 1;

            if (IsAlphabet(lastChar) && !IsLowerAlphabet(c) && !IsNumber(c, out _))
                curNumber = 1;

            if (curNumber > 0 && !IsNumber(c, out _)) {
                var success = AddElementIf(curNumber, curElement);
                if (success)
                    curElement = string.Empty;
                else // add group
                    AddGroupElement(curNumber);

                curNumber = 0;
            }

            if (IsNumber(c, out var n))
                curNumber = curNumber > 0
                    ? curNumber * 10 + n
                    : n;
            else if (c == '(') {
                stackMap.Push(mapElement);
                mapElement = new Dictionary<string, int>();
            }
            else if (IsUpperAlphabet(c)) // new element
                curElement = $"{c}";
            else if (IsLowerAlphabet(c))
                curElement += c;

            lastChar = c;
        }

        var a = rootMapElement.OrderBy(p => p.Key)
            .Select(p => p.Value > 1 ? $"{p.Key}{p.Value}" : $"{p.Key}")
            .Aggregate((final, next) => final + next);

        return a;

        bool AddElementIf(int number, string element) {
            if (number <= 0 || string.IsNullOrEmpty(element)) return false;
            mapElement.TryGetValue(element, out var n);
            mapElement[element] = number + n;
            return true;
        }

        void AddGroupElement(int number) {
            var closeMapElement = mapElement;
            mapElement = stackMap.Pop();
            // multiply for list element
            foreach (var keyValuePair in closeMapElement)
                closeMapElement[keyValuePair.Key] = keyValuePair.Value * number;
            // merge mapElement to its parent
            MergeMap(closeMapElement, mapElement);
        }
    }

    private static void MergeMap(Dictionary<string, int> child, Dictionary<string, int> parent) {
        foreach (var keyValuePair in child) {
            parent.TryGetValue(keyValuePair.Key, out var v);
            parent[keyValuePair.Key] = v + keyValuePair.Value;
        }
    }

    private static bool IsLowerAlphabet(char c) => c is >= 'a' and <= 'z';
    private static bool IsUpperAlphabet(char c) => c is >= 'A' and <= 'Z';
    private static bool IsAlphabet(char c) => IsLowerAlphabet(c) || IsUpperAlphabet(c);

    private static bool IsNumber(char c, out int result) {
        if (c is >= '0' and <= '9') {
            result = c - '0';
            return true;
        }

        result = default;
        return false;
    }

    public static void Test() {
        NumberOfAtom("Ca(OH)2Fe2O3");
        NumberOfAtom("H2O");
        NumberOfAtom("Mg(OH)2");
        NumberOfAtom("K4(ON(SO3)2)2");
    }
}