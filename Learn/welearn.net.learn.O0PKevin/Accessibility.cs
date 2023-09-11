using  welearn.net.learn.OOP;

namespace welearn.net.learn.O0PKevin; 

public class Accessibility {
    private TopLevelPublicClass _topLevelPublicClass;
    //TopLevelInternalClass b; // can't access
    // TopLevelDefaultInternalClass b // can't access
    public void TopLevelPublicClass() {
        _topLevelPublicClass = new ();
        // a.Age // can't access
    }
}