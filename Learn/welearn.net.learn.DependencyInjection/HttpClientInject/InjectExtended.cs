using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace welearn.net.learn.DependencyInjection.HttpClientInject; 

public static class InjectExtended {
    public static IServiceCollection AddSpecificSingleton<
        TService,
        TDependencyImplement>(
        this IServiceCollection services)
        where TService : class
        where TDependencyImplement : class
    {
        return services.AddSingleton<TService>(sp => {
            var service = sp.GetRequiredService<TDependencyImplement>();
            return (TService)ActivatorUtilities.CreateInstance(sp, typeof(TService), service);
        });
    }
}