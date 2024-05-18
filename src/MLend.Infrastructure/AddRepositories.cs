using MLend.Application;
using MLend.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class AddRepositories 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
    {
        services.AddScoped<ILendRepository, LendRepository>();
        services.AddScoped<IDbContext, DbContext>();
        return services;
    }
}
