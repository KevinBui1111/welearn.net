namespace welearn.net.learn.csharp.Generic; 

public static class GenericClass  {
    public static T? Foo<T>(bool nullValue, T defaultValue) where T : struct {
        return nullValue ? null : defaultValue;
    }

    public static T? Bar<T>(bool nullValue, T? defaultValue) where T : class {
        return nullValue ? default : defaultValue;
    }
}