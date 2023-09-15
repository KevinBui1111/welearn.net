namespace welearn.net.algo.piece;

public class LangfordPairing {
    private int[] _lots;
    private int _numInput;
    private int _maxFirst;
    private bool _firstMiddle;
    private readonly Stack<(int pairNth, int startPosition)> _stack = new();

    public LangfordPairing() {
        Reset(3);
    }

    public void Reset(int numInput) {
        _numInput = numInput;
        _maxFirst = (_numInput - 1) / 2 + (_numInput - 1) % 2;
        _firstMiddle = false;
        _lots = new int[numInput * 2];
        _stack.Clear();
    }

    public int Arrange(int numInput) {
        // int lots
        Reset(numInput);

        PlaceNPush(_numInput, 0);
        var curStateSuccess = true;
        var nSolution = 0;
        do {
            var cur = _stack.Peek();
            // try next pair, previous less than

            if (cur.pairNth == 1) {
                // success
                ++nSolution;
                PrintSolution();
                UnPlaceNPop();
                curStateSuccess = false;
                continue;
            }

            (int pairNth, int fromPosition) testObj;
            if (curStateSuccess) {
                // next pairNth, find lot to put.
                testObj = (cur.pairNth - 1, 0);
            }
            else {
                UnPlaceNPop();
                testObj = (cur.pairNth, cur.startPosition + 1);
            }

            (curStateSuccess, var position) = FindNextPlace(testObj.pairNth, testObj.fromPosition);
            if (curStateSuccess) {
                PlaceNPush(testObj.pairNth, position);
            }
        } while (_stack.Count != 0);

        return nSolution;
    }

    private void UnPlaceNPop() {
        var cur = _stack.Pop();
        (_lots[cur.startPosition], _lots[cur.startPosition + cur.pairNth + 1]) = (0, 0);
    }

    private void PlaceNPush(int pairNth, int position) {
        if (_numInput % 2 == 0 && pairNth == _numInput && position == _maxFirst - 1)
            _firstMiddle = true;

        (_lots[position], _lots[position + pairNth + 1]) = (pairNth, pairNth);
        _stack.Push((pairNth, position));
    }

    private (bool success, int position) FindNextPlace(int pairNth, int startFrom = 0) {
        var max = pairNth == _numInput ? _maxFirst :
            _firstMiddle && pairNth == _numInput - 1 ? _maxFirst :
            _numInput * 2 - pairNth - 1;

        for (var startPosition = startFrom; startPosition < max; ++startPosition) {
            var isOk = IsAvailableAt(pairNth, startPosition);
            if (!isOk) continue;

            return (true, startPosition);
        }

        return (false, 0);
    }

    private bool IsAvailableAt(int pairNth, int startPosition) {
        var endPosition = startPosition + pairNth + 1;
        return endPosition < _lots.Length &&
               _lots[startPosition] == 0 &&
               _lots[endPosition] == 0
            ;
    }

    private bool TryPlace(int pairNth, int startPosition) {
        var isOk = IsAvailableAt(pairNth, startPosition);
        if (isOk) {
            (_lots[startPosition], _lots[startPosition + pairNth + 1]) = (pairNth, pairNth);
        }

        return isOk;
    }

    private void PrintSolution() {
        // Console.WriteLine(string.Join(' ', lots));
    }
}