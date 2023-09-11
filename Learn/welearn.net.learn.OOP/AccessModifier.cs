namespace welearn.net.learn.OOP;

/// top level type /
/// Classes, records, and structs declared directly within a namespace
/// (in other words, that aren't nested within other classes or structs)
/// can be either public or internal (default)
class TopLevelDefaultInternalClass { }

internal class TopLevelInternalClass {
    //Why use a public method in an internal class?
    public string Name = "aaa";
}

public class TopLevelPublicClass {
    public string Name { get; set; }
    public int Number { get; set; }

    internal int Age { get; set; }
}