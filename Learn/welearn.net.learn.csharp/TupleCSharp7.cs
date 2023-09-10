namespace welearn.net.learn.csharp; 

// move from ConsoleCore project, 2020-03-13 - 26
internal class TupleCSharp7 {
    private class User {
        public string Name { set; get; }
        public int Age { get; set; }
        
        public void Deconstruct(out int firstName, out string lastName) => (firstName, lastName) = (Age, Name);
    }

    private static (string, int) TripleValue((string name, int age) user) {
        user.age *= 3;
        user.name += user.name + user.name;

        return user;
    }

    public static void Test() {
        // quick declaration, tuple style.
        Console.WriteLine("---Tuple declaration---");
        var (age, name) = (34, "Kevin");
        // same as: (string age, int name)  = (34, "Kevin");
        Console.WriteLine($"{(age, name)} | {age} - {name}"); // (34, Kevin) | 34 - Kevin

        var user = ("Kevin", 34);
        Console.WriteLine($"{user} | {user.Item1} - {user.Item2}"); // (Kevin, 34) | Kevin - 34
        
        var user2 = (name: "Kevin", age: 34);
        // same as: (string name, int age) user4 = ("Kevin", 34);
        Console.WriteLine($"{user2.name} - {user2.age}"); // Kevin - 34
        
        var user3 = (name, age);
        Console.WriteLine($"{user3.name} - {user3.age}"); // Kevin - 34
        
        Console.WriteLine("\n---Tuple is structure, and is value type---");
        user3.age++;
        Console.WriteLine(user2 == user3); // false
        
        ++user2.age;
        Console.WriteLine(user2 == user3); // true

        var user4 = user3;
        user3.name = "Kute Gultton";
        user3.age = 31;
        Console.WriteLine($"user3: {user3}, user4: {user4}"); // user3: (Kute Gultton, 31), user4: (Kevin, 35)

        Console.WriteLine("\n---Pass to method, can't change value--");
        var userTriple = TripleValue(user);
        Console.WriteLine($"{userTriple}, {user}"); // (KevinKevinKevin, 102), (Kevin, 34)

        Console.WriteLine("\n---Destructor---");
        (_, name) = new User { Age = 20, Name = "Eni" };
        Console.WriteLine($"name: {name}"); // Eni
        
        Console.WriteLine("\n---exchange in array---");

        int[] a = { 1, 2, 3 };
        (a[0], a[1], a[2]) = (a[1], a[2], a[0]);
        Console.WriteLine($"array {a[0]} - {a[1]} - {a[2]}"); // 2 - 3 - 1
    }
}