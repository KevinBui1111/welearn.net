namespace welearn.net.learn.csharp;

public class Person {
    private string _firstName;
    private string _lastName;

    public Person(string first, string last) {
        _firstName = first;
        _lastName = last;
        Gender = 1;
    }

    public string Name => $"{_lastName} {_firstName}";

    public int Age { get; set; }
    public int Gender { get; }
    public string InitProp { get; set; } = "initValue";
}

public class Properties {
    public static void Test() {
        var p = new Person("Khanh", "Bui");
        Console.WriteLine(p.Name); //Bui Khanh
        //p.Name = "Bui Khanh"; //The property 'Person.Name' has no setter
        Console.WriteLine(p.Age); //0
        p.Age = 10;
        Console.WriteLine(p.Age); //10
        Console.WriteLine(p.Gender); //1
    }
}