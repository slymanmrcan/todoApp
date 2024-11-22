using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace MVC.Extentions;

public static class DbConnections
{
    public static IServiceCollection AddDatabaseConnections(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IDbConnection>(sp => 
            new SqlConnection(configuration.GetConnectionString("sqlServer")));

        services.AddTransient<IDbConnection>(sp => 
            new NpgsqlConnection(configuration.GetConnectionString("postgresql")));

        return services;
    }
}