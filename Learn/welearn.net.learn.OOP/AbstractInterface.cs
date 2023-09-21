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