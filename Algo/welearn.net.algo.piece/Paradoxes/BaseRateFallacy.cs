namespace welearn.net.algo.piece.Paradoxes;

public class BaseRateFallacy {
    /*
     * A disease affects 1% of the population.
     * The test has 99% sensitivity and a 5% false positive rate.
     * One man is tested and the result is positive.
     * What is the probability that he actually has the disease?
     *
     * S: event of sick
     * P: event positive test
     *
     * P(S)    = 01%
     * P(P|S)  = 99%
     * P(P|¬S) = 05%
     *
     * P(P) = P(P|S) x P(S) + P(P|¬S) x P(¬S)
     *      = 0.99 x 0.01 + 0.05 x 0.99
     *      = 0.0099 + 0.0495
     *      = 0.0594
     *
     * P(S|P) = P(S) x P(P|S) / P(P)
     *        = 0.01 x 0.99 / 0.0594
     *        = 0.0099 / 0.0594
     *        ≈ 0.1667

        Toàn bộ dân số (100%)
        |
        +-- Mắc bệnh S (1%)
        |   |
        |   +-- Dương tính P (99%)
        |   |   => 1% × 99% = 0.99%
        |   |
        |   +-- Âm tính ¬P (1%)
        |       => 1% × 1% = 0.01%
        |
        +-- Không mắc bệnh ¬S (99%)
            |
            +-- Dương tính P (5%)
            |   => 99% × 5% = 4.95%
            |
            +-- Âm tính ¬P (95%)
                => 99% × 95% = 94.05%

     */
    public static void BaseRateFallacySimulate(int tryCount) {
        const int pSickInCivil = 1; // 1%
        const int pPositiveGivenSick = 99; // 99%
        const int pPositiveGivenNotSick = 5; // 5%

        var cntPositives = 0;
        var truePositives = 0;
        for (var i = 0; i < tryCount; i++) {
            // Simulation logic goes here
            var sickMan = Random.Shared.Next(100) < pSickInCivil; // false if healthy, true if sick
            var testPositive = sickMan
                ? Random.Shared.Next(100) < pPositiveGivenSick
                : Random.Shared.Next(100) < pPositiveGivenNotSick;
            if (testPositive) {
                ++cntPositives;
                if (sickMan) ++truePositives;
            }
        }

        Console.WriteLine($"True positives probability: {(double)truePositives / cntPositives:P}");
    }
}