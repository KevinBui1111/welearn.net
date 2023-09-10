namespace welearn.net.algo.piece;

public class LangfordPairing_v2 {
    private int[] lots;
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
        lots = new int[numInput * 2];
        _nSolution = 0;
    }

    public int Arrange(int numInput) {
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
            var subSuccess = Arrange(pairNth - 1, 0);
            UnPlace(pairNth, position);
            Arrange(pairNth, position + 1);
        }

        return success;
    }

    private void UnPlace(int pairNth, int position) {
        (lots[position], lots[position + pairNth + 1]) = (0, 0);
    }

    private void Place(int pairNth, int position) {
        if (_numInput % 2 == 0 && pairNth == _numInput && position == _maxFirst - 1)
            _firstMiddle = true;
        
        (lots[position], lots[position + pairNth + 1]) = (pairNth, pairNth);
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
        return endPosition < lots.Length &&
               lots[startPosition] == 0 &&
               lots[endPosition] == 0
            ;
    }

    private void PrintSolution() {
        // Console.WriteLine(string.Join(' ', lots));
    }
}