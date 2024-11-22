using MVC.Services;

namespace MVC.Extentions;

public static class AddServiceExtentions
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGeneriService<>), typeof(GenericService<>));
        services.AddScoped<ITodoService, TodoService>();
        return services; 
    }
}

