namespace welearn.net.algo.piece.Paradoxes;

public static class BertrandBox {
    public static void ChoiceGold(int testCnt) {
        // two boxes, two items per box. 1 is gold, 0 is silver
        var boxes = new int[][] { [1, 1], [1, 0] };

        int total = 0, totalLeftGold = 0;

        for (var i = 0; i < testCnt; ++i) {
            var choiceBox = boxes[Random.Shared.Next(2)];
            var choiceItemIndex = Random.Shared.Next(2);

            if (choiceBox[choiceItemIndex] != 1) continue;

            ++total;
            if (choiceBox[1 - choiceItemIndex] == 1)
                ++totalLeftGold;
        }

        Console.WriteLine($"Total left gold items: {totalLeftGold} / Total gold items chosen: {total}");
        Console.WriteLine($"Probability of left gold given chosen gold: {(double)totalLeftGold / total:P}");
    }

}