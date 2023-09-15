namespace welearn.net.algo.piece;

public class LangfordPairing_v2{
    private int[] _lots;
    private int _numInput;
    private int _maxFirst;
    private bool _firstMiddle;
    private int _nSolution;

    public bool StopAtFirst {
        get;
        set;
    }

    public LangfordPairing_v2() {
        Reset(3);
    }

    public void Reset(int numInput) {
        _numInput = numInput;
        _maxFirst = (_numInput - 1) / 2 + (_numInput - 1) % 2;
        _firstMiddle = false;
        _lots = new int[numInput * 2];
        _nSolution = 0;
    }

    public int Arrange(int numInput) {
        // Multiples of four, and one less than,
        // ie: Langford pairings exist only when n is congruent to 0 or 3 modulo 4
        if (numInput % 4 is not 3 and not 0) return 0;
        
        Reset(numInput);
        Arrange(numInput, 0);
        return _nSolution;
    }

    private bool Arrange(int pairNth, int fromPosition) {
        var (success, position) = FindNextPlace(pairNth, fromPosition);
        if (!success) return success;
        
        Place(pairNth, position);
        if (pairNth == 1) {
            PrintSolution();
            UnPlace(pairNth, position);
            ++_nSolution;
        }
        else {
            success = Arrange(pairNth - 1, 0);
            if (StopAtFirst && success) return success;
            UnPlace(pairNth, position);
            success = Arrange(pairNth, position + 1);
        }

        return success;
    }

    private void UnPlace(int pairNth, int position) {
        (_lots[position], _lots[position + pairNth + 1]) = (0, 0);
    }

    private void Place(int pairNth, int position) {
        if (_numInput % 2 == 0 && pairNth == _numInput && position == _maxFirst - 1)
            _firstMiddle = true;
        
        (_lots[position], _lots[position + pairNth + 1]) = (pairNth, pairNth);
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

    private void PrintSolution() {
        Console.WriteLine(string.Join(' ', _lots));
    }
}