namespace welearn.net.algo.piece.LeetCode;

public class AtomCounter {
    public static string NumberOfAtom(string chemicalFormula) {
        var lastChar = '\0';
        var curElement = string.Empty;
        var rootMapElement = new Dictionary<string, int>();
        var mapElement = rootMapElement;
        var stackMap = new Stack<Dictionary<string, int>>([rootMapElement]);

        foreach (var c in chemicalFormula) {
            if (lastChar == ')') {
                var closeMapElement = mapElement;
                mapElement = stackMap.Pop();
                
                if (IsNumber(c, out var n)) {
                    // multiply for list element
                    foreach (var keyValuePair in closeMapElement)
                        closeMapElement[keyValuePair.Key] = keyValuePair.Value * n;
                }

                // merge mapElement to its parent
                MergeMap(closeMapElement, mapElement);
                closeMapElement.Clear();
            }

            AddElementIf(c);

            if (c == '(') {
                stackMap.Push(mapElement);
                mapElement = new Dictionary<string, int>();
            }
            else if (IsUpperAlphabet(c)) // new element
                curElement = $"{c}";
            else if (IsLowerAlphabet(c))
                curElement += c;

            lastChar = c;
        }

        AddElementIf('1');

        return string.Empty;

        void AddElementIf(char c) {
            if (!IsAlphabet(lastChar)) return;
            if (IsNumber(c, out var n)) {
                mapElement.TryGetValue(curElement, out var v);
                mapElement[curElement] = v + n;
            }
            else if (!IsLowerAlphabet(c))
                mapElement[curElement] = 1;
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
        if (c is >= '2' and <= '9') {
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