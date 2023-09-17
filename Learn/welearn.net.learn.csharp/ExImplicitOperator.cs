namespace welearn.net.learn.csharp;

public class EniOperator {
    public string EniWord { get; set; }

    public EniOperator(string eniWord) {
        EniWord = eniWord;
    }
}

public class AniOperator {
    public string AniWord { get; set; }

    public AniOperator(string aniWord) {
        AniWord = aniWord;
    }
    
    public static implicit operator EniOperator(AniOperator aniOperator) {
        return new EniOperator(aniOperator.AniWord + " too");
    }
    
    public static implicit operator AniOperator(EniOperator eniOperator) {
        return new AniOperator(eniOperator.EniWord + " so much");
    }
    
    public static implicit operator AniOperator(string aniWord) {
        return new AniOperator(aniWord);
    }
    
    public static implicit operator string(AniOperator aniWord) {
        return aniWord.AniWord;
    }
}

public class ExImplicitOperator {
    public static void Test() {
        var ani = new AniOperator("I love u");
        EniOperator eni = ani;
        ani = eni;
        
        Console.WriteLine(eni.EniWord);
        Console.WriteLine(ani.AniWord);

        ani = "Eni I miss you";
        Console.WriteLine(ani.AniWord);
        string word = ani;
        Console.WriteLine(word);
    }
} 