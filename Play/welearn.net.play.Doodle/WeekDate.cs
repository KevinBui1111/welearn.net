namespace welearn.net.play.Doodle; 

public class WeekDate {
    public static void ListAllWeek(int year) {
        var d = new DateTime(year,01, 01);

        while (d.Year == year) {
            var file = $"{d.Day:0#}";
            if (d.DayOfWeek != DayOfWeek.Sunday) {
                var d2 = d.AddDays(7 - (int)d.DayOfWeek).Day;
                if (d2 < d.Day)
                    d2 = DateTime.DaysInMonth(d.Year, d.Month);
        
                file = $"{d.Day:0#}-{d2:0#}";
                d = new DateTime(d.Year, d.Month, d2);
            }

            Console.WriteLine($"{d:yyyy-MM} {file}");
            d = d.AddDays(1);
        }
    }
}