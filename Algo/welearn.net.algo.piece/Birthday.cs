namespace welearn.net.algo.piece;

public class Birthday {
    public static void Test() {
        var manAmount = 40;
        var probability = CalcProbabilitySameBirthday2(manAmount);
        Console.WriteLine($"Probability for having two person have same birthdate: {probability:P}");

        var p = 0.9;
        var groupSize = FindLinearX.FindX(CalcProbabilitySameBirthday2, 20, p);
        Console.WriteLine($"Size group that have probability {p:P} for three persons share same birthdate: {groupSize}");
    }
    
    public static double CalcProbabilitySameBirthday(int manAmount) {
        const int testCnt = 10_000;

        var match = 0;
        for (var i = 0; i < testCnt; ++i) {
            var group = GenRandomGroup(manAmount);
            // mathCnt += HaveCoupleSameBirthday(birthdays) ? 1 : 0;
            match += HaveTripleSameBirthday(group) ? 1 : 0;
        }

        return match * 1.0 / testCnt;
    }
    
    // from a Dung (Head)
    public static double CalcProbabilitySameBirthday2(int manAmount) {
        const int testCnt = 10_000;

        const int maxDay = 366;
        var match = Enumerable.Range(0, testCnt).Count(_ => {
            var check365 = new int[maxDay];

            return Enumerable.Range(0, manAmount).Any(_ => {
                var day = Random.Shared.Next(maxDay);

                if (check365[day] == 1) return true;
                check365[day] = 1;
                return false;
            });
        });

        return match * 1.0 / testCnt;
    }
    
    private static IEnumerable<DateOnly> GenRandomDates(int count) {
        var today = DateOnly.FromDateTime(DateTime.Today);
        const int range = 365 * 200;
        return Enumerable.Range(1, count)
            .Select(_ => today.AddDays(Random.Shared.Next(range)));
    }

    private static IEnumerable<DateOnly> GenRandomGroup(int count) {
        var firstDate = new DateOnly(2024, 01, 01);
        return Enumerable.Range(1, count)
            .Select(_ => firstDate.AddDays(Random.Shared.Next(366)));
    }
    
    private static bool HaveCoupleSameBirthday(IEnumerable<DateOnly> birthdays) {
        var dateSet = new HashSet<DateTime>();
        return birthdays
            .Select(date => new DateTime(2024, date.Month, date.Day))
            .Any(dateOnly => !dateSet.Add(dateOnly));
    }

    private static bool HaveTripleSameBirthday(IEnumerable<DateOnly> birthdays) {
        var dateSet = new Dictionary<DateTime, int>();
        return birthdays
            .Select(date => new DateTime(2024, date.Month, date.Day))
            .Any(dateOnly => {
                if (!dateSet.TryAdd(dateOnly, 1))
                    dateSet[dateOnly] += 1;

                return dateSet[dateOnly] == 3;
            });
    }
}