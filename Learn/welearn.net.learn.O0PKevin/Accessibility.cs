using  welearn.net.learn.OOP;

namespace welearn.net.learn.O0PKevin; 

public class Accessibility {
    private TopLevelPublicClass _topLevelPublicClass;
    //TopLevelInternalClass b; // can't access
    // TopLevelDefaultInternalClass b // can't access
    public void Access_TopLevelPublicClass() {
        _topLevelPublicClass = new ();
        // _topLevelPublicClass.Age // can't access
    }
}

internal class InheritFromTopLevelPub : TopLevelPublicClass {
    public void AccessParent() {
        /* cannot access
        PrivateProtectedMethod();
        var p = PrivateProtectedField;
        */
        // can access protected & protected internal
        ProtectedInternalMethod();
        ProtectedInternalField = 11;
        
        ProtectedMethod();
        ProtectedField = 11;
    }
}