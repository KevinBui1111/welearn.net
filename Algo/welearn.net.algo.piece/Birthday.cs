namespace welearn.net.algo.piece;

public class Birthday
{
    public static void CalcProbabilitySameBirthday()
    {
        // generate random 100 date
        const int manAmount = 23;
        var today = DateTime.Today;
        const int range = 1000;
        const int testCnt = 1000;

        var mathCnt = 0;
        for (var i = 0; i < testCnt; ++i)
        {
            var birthdays = Enumerable.Range(1, manAmount)
                .Select(_ => today.AddDays(Random.Shared.Next(range)));
            
            mathCnt += HaveSameBirthday(birthdays) ? 1 : 0;
        }

        var probability = mathCnt * 1.0 / testCnt;
        Console.WriteLine($"Probability for having two person have same birthdate: {probability:P}");
    }

    private static bool HaveSameBirthday(IEnumerable<DateTime> birthdays)
    {
        var dateSet = new HashSet<DateTime>();
        return birthdays
            .Select(date => new DateTime(2024, date.Month, date.Day))
            .Any(dateOnly => !dateSet.Add(dateOnly));
    }
}