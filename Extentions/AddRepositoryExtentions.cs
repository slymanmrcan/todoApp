using MVC.Repositories;

namespace MVC.Extentions;

public static class AddRepositoryExtentions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ITodoRepositories, TodoRepositories>();
        return services; 
    } 
}