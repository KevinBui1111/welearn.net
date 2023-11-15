namespace welearn.net.learn.OOP;

public interface IAnimal {
    void Speak();
    void Run();
}
   
public abstract class Homo : IAnimal {
    public abstract void Speak();
    public virtual void Run() {
        throw new NotImplementedException();
    }
}

public class Human : Homo {
    public override void Speak() {
        throw new NotImplementedException();
    }

    public override void Run() {
        throw new NotImplementedException();
    }
}

public interface IRobot {
    void Speak();
}

public class Assistant : IAnimal, IRobot {
    void IAnimal.Speak() {
        throw new NotImplementedException();
    }

    public void Run() {
        throw new NotImplementedException();
    }

    void IRobot.Speak() {
        throw new NotImplementedException();
    }
}

public class AbstractInterface {
    public static void Main() {
        var a = new Assistant();
        // a.Speak(); Compiler error: cannot access 
    }
}