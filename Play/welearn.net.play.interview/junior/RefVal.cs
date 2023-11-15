namespace welearn.net.play.interview.junior; 

public class RefVal {
    public static void Test() {
        var tenors = new List<int> { 3, 6, 12, 24 };
        ProcessList(tenors);
        Console.WriteLine(string.Join(',', tenors));
    }

    private static void ProcessList(IList<int> numbers) {
        numbers.Add(36);
        numbers = numbers.Where(t => t > 10).ToList();
    }
}