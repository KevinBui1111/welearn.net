namespace welearn.net.learn.csharp.Entities; 

public class Student {
    public int Age { get; init; }
    public string Name { get; init; }
    
    public Student(int age, string name) {
        Age = age;
        Name = name;
    }

    public override string ToString() => $"{Age}-{Name}";
}