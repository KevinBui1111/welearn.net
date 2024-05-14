namespace welearn.net.algo.piece;

public class Birthday {
    public static void Test() {
        var manAmount = 88;
        var probability = CalcProbabilitySameBirthday(manAmount);
        Console.WriteLine($"Probability for having two person have same birthdate: {probability:P}");

        var p = 0.9;
        var groupSize = FindLinearX.FindX(CalcProbabilitySameBirthday, 20, p);
        Console.WriteLine($"Size group that have probability {p:P} for three persons share same birthdate: {groupSize}");
    }
    
    public static double CalcProbabilitySameBirthday(int manAmount) {
        // generate random 100 date
        const int testCnt = 10_000;

        var mathCnt = 0;
        for (var i = 0; i < testCnt; ++i) {
            var birthdays = GenRandomDates2(manAmount);
            // mathCnt += HaveCoupleSameBirthday(birthdays) ? 1 : 0;
            mathCnt += HaveTripleSameBirthday(birthdays) ? 1 : 0;
        }

        return mathCnt * 1.0 / testCnt;
    }

    private static IEnumerable<DateOnly> GenRandomDates(int count) {
        var today = DateOnly.FromDateTime(DateTime.Today);
        const int range = 365 * 200;
        return Enumerable.Range(1, count)
            .Select(_ => today.AddDays(Random.Shared.Next(range)));
    }

    private static IEnumerable<DateOnly> GenRandomDates2(int count) {
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