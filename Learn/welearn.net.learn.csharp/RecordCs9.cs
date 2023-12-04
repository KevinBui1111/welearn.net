using System.Diagnostics;

namespace welearn.net.learn.csharp; 

//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record
public record /*class*/ Marble (int Size, ConsoleColor Color);
public record struct Card (int Form, int Type);
public record PersonRecord
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
};

public class RecordCs9 {
    public static void Main() {
        var m1 = new Marble(5, ConsoleColor.Cyan);
        var m2 = m1;
        // m1.Size = 5; //Error: Init-only property
        Debug.Assert(ReferenceEquals(m1, m2));

        var c1 = new Card(1, 2);
        var c2 = c1;
        Debug.Assert(!ReferenceEquals(c1, c2));
        Debug.Assert(c1 == c2);

        var p = new PersonRecord();
        Console.WriteLine($"p = {p}");
        p.FirstName = "Kevin";
        Console.WriteLine($"p = {p}");
        p.FirstName = "khanh";
        Console.WriteLine($"p = {p}");
    }
}