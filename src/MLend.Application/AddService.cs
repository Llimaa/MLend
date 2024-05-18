using MLend.Application;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddService 
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<ILendService, LendService>();
        return services;
    }
}
