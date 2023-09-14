namespace welearn.net.learn.OOP;

/// top level type /
/// Classes, records, and structs declared directly within a namespace
/// (in other words, that aren't nested within other classes or structs)
/// can be either public or internal (default)
class TopLevelDefaultInternalClass { }

internal class TopLevelInternalClass {
    //Why use a public method in an internal class?
    public string Name = "aaa";

    public void Access_TopLevelPublicClass() {
        var topLevelPub = new TopLevelPublicClass();
        /* can access type or member has `internal` modifier,
        cannot access
        topLevelPub.ProtectedField;
        topLevelPub.ProtectedMethod
        */
        topLevelPub.InternalAge = 11;
        topLevelPub.ProtectedInternalMethod();
        topLevelPub.ProtectedInternalField = 11;
    }
}

public class TopLevelPublicClass {
    public string Name { get; set; }
    public int Number { get; set; }

    internal int InternalAge { get; set; }

    // implicit private modifier
    /*private*/void PrivateMethod() { }

    protected int ProtectedField = 19;
    protected void ProtectedMethod() {
        //can be accessed by types derived from the class,
        //don't care same / different assembly.
    }

    private protected int PrivateProtectedField = 19;
    private protected void PrivateProtectedMethod() {
        //can be accessed by types derived from the class, and
        //that are declared within its containing assembly.
    }

    protected internal int ProtectedInternalField = 19;
    protected internal void ProtectedInternalMethod() {
        //can be accessed by types derived from the class, or
        //class are declared within its containing assembly.

        //cannot access from non-derived class from different assembly.
    }
}

internal class InheritFromTopLevelPub : TopLevelPublicClass {
    public void AccessParent() {
        // can access all except private.

        PrivateProtectedMethod();
        PrivateProtectedField = 11;

        ProtectedInternalMethod();
        ProtectedInternalField = 11;

        ProtectedMethod();
        ProtectedField = 11;

        Console.WriteLine($@"
            {PrivateProtectedField}
            {ProtectedInternalField}
            {ProtectedField}"
        );
    }
}