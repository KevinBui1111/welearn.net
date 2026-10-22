namespace welearn.net.algo.piece.Paradoxes;

public class ThreePrisonerProblem {
    /*
     * https://en.wikipedia.org/wiki/Three_prisoners_problem
     * Three prisoners (A, B, and C) are sentenced to death.
     * The governor secretly pardons one of them at random.
     * Prisoner A asks the warden (who knows the truth) to name one of the other two who will be executed.
     * The warden replies: "B will be executed".
     * Calculate the probability of being pardoned of A and C, given that above information.
     */
    public static void ThreePrisonerProblemSimulate(int tryCount) {
        (int total, int pardonedA, int pardonedC) statistic = (0, 0, 0);

        for (var i = 0; i < tryCount; i++) {
            // Randomly select one prisoner to be pardoned
            var pardonedPrisoner = Random.Shared.Next(3); // 0: A, 1: B, 2: C

            // randomly select one of B or C to be executed, given that A is asking
            var wardenAnswer = pardonedPrisoner == 0
                // if A is pardoned, warden can answer either B or C
                ? Random.Shared.Next(1, 3)
                // if B or C is pardoned, warden must answer the other one
                : 3 - pardonedPrisoner;

            if (wardenAnswer == 1) {
                // Warden says B will be executed
                ++statistic.total;
                if (pardonedPrisoner == 0) ++statistic.pardonedA;
                else ++statistic.pardonedC;
            }
        }

        var probA = (double)statistic.pardonedA / statistic.total;
        var probC = (double)statistic.pardonedC / statistic.total;

        Console.WriteLine($"Probability of A being pardoned: {probA:P}");
        Console.WriteLine($"Probability of C being pardoned: {probC:P}");
    }
}