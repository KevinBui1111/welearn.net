namespace welearn.net.algo.piece.Paradoxes;

public class SleepingBeauty {
    /*
     * Sunday: Sleeping Beauty is put to sleep, and a fair coin is flipped (Heads or Tails, each with a 50% chance).
     * Heads: She is awakened on Monday only, then put back to sleep with her memory erased.
     * Tails: She is awakened on Monday, put back to sleep with her memory erased, and awakened again on Tuesday.
     * Upon Waking:
     * - Whenever she wakes up, she has no idea what day it is or whether she has been woken up before.
     * - She is asked: What is the probability that the coin landed on Heads?
     */
    public void Simulate(int tryCnt) {
        int mondayWakeupCount = 0,
            tuesdayWakeupCount = 0;

        for (var i = 0; i < tryCnt; i++) {
            var isHeads = Random.Shared.Next(2) == 0; // Flip the coin
            
            ++mondayWakeupCount;
            if (!isHeads) {
                ++tuesdayWakeupCount;
            }
            
            // can not simulate this puzzle
        }
    }
}