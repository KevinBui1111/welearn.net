namespace welearn.net.algo.piece.Paradoxes;

public class PairOfAces {
    /*
     * Given a standard 52-card deck, two cards are drawn in each of three independent games.
     * Game 1: At least one card is an ace.
     * Game 2: At least one card is a black ace (Ace of Spades or Ace of Clubs).
     * Game 3: At least one card is the Ace of Spades.
     * Which game has the highest probability of drawing a pair of aces, given that each game satisfies a different condition?
     */
    public static void PairOfAcesSimulate(int tryCount) {
        (int total, int pair) atLeast = (0, 0);
        (int total, int pair) atLeastBlack = (0, 0);
        (int total, int pair) haveSpade = (0, 0);

        for (var i = 0; i < tryCount; i++) {
            // Simulation logic goes here
            var deck = Enumerable.Range(1, 52).ToList();
            // assume 4 aces:
            // - 1: Ace of Spades
            // - 2: Ace of Clubs
            // - 3: Ace of Diamonds
            // - 4: Ace of Hearts

            // shuffle the deck
            deck = deck.OrderBy(_ => Random.Shared.Next()).ToList();
            // pick the first two cards
            var firstCard = deck[0];
            var secondCard = deck[1];
            var pairOfAces = firstCard <= 4 && secondCard <= 4 ? 1 : 0;

            // check if at least one card is an ace
            if (firstCard <= 4 || secondCard <= 4) {
                ++atLeast.total;
                // check if both cards are aces
                atLeast.pair += pairOfAces;
            }

            // check if at least one card is a black ace
            if (firstCard <= 2 || secondCard <= 2) {
                ++atLeastBlack.total;
                // check if both cards are aces
                atLeastBlack.pair += pairOfAces;
            }

            // check if at least one card is the Ace of Spades
            if (firstCard == 1 || secondCard == 1) {
                ++haveSpade.total;
                // check if both cards are aces
                haveSpade.pair += pairOfAces;
            }
        }

        // Calculate probabilities
        var probAtLeast = (double)atLeast.pair / atLeast.total;
        var probAtLeastBlack = (double)atLeastBlack.pair / atLeastBlack.total;
        var probHaveSpade = (double)haveSpade.pair / haveSpade.total;

        Console.WriteLine("Probability of pair of aces given at:");
        Console.WriteLine($"- Least one ace: {probAtLeast:P}");
        Console.WriteLine($"- Least one black ace: {probAtLeastBlack:P}");
        Console.WriteLine($"- Have Ace of Spades: {probHaveSpade:P}");
    }
}
        