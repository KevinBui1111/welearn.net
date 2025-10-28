using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace welearn.net.learn.DependencyInjection.Generic;

public class RegisterGeneric {
    public static void Test() {
        var sc = new ServiceCollection();
        sc.AddScoped(typeof(IDomainGen<>), typeof(DomainGen<>));
        var sp = sc.BuildServiceProvider();

        var domainGenStr = sp.GetRequiredService<IDomainGen<string>>();
        Debug.Assert("abc" == domainGenStr.UpdateValue("abc"));
        
        var domainGenInt = sp.GetRequiredService<IDomainGen<int>>();
        Debug.Assert(10 == domainGenInt.UpdateValue(10));
    }
}

public interface IDomainGen<T> {
    T UpdateValue(T value);
}

public class DomainGen<T> : IDomainGen<T> {
    public T UpdateValue(T value) {
        return value;
    }
}
