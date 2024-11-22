namespace MVC.Extentions;

public static class GetConnectionString
{
    public static string GetConnectionStringExtension(IConfiguration configuration)
    {
        return configuration.GetConnectionString("postgresql") ?? string.Empty;
    }
}