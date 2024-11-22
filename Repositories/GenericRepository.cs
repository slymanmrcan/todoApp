using System.Data;
using System.Data.SqlClient;
using Dapper;
using MVC.Extentions;
using Npgsql;

namespace MVC.Repositories;

public class GenericRepository<T>:IGenericRepository<T> where T : class
{
    private readonly IDbConnection _dbConnection;
    private readonly string _tableName;
    public GenericRepository(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("postgresql");
        _dbConnection = new NpgsqlConnection(connectionString);
        _tableName = typeof(T).Name+"s"; // TodoModel -> Todos
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {_tableName}";
        return await _dbConnection.QueryAsync<T>(sql);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<T>(sql, new { Id = id });
    }

    public async Task AddAsync(T entity)
    {
        // Entity'nin property'lerini al
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.GetValue(entity) != null)
            .ToList();

        var columnNames = string.Join(", ", properties.Select(p => p.Name));
        var paramNames = string.Join(", ", properties.Select(p => "@" + p.Name));

        var sql = $"INSERT INTO {_tableName} ({columnNames}) VALUES ({paramNames})";
        
        await _dbConnection.ExecuteAsync(sql, entity);
    }

    public async Task UpdateAsync(T entity)
    {
        var properties = typeof(T).GetProperties()
            .Where(p => p.Name != "Id" && p.GetValue(entity) != null)
            .ToList();

        var setStatements = string.Join(", ", 
            properties.Select(p => $"{p.Name} = @{p.Name}"));

        var sql = $"UPDATE {_tableName} SET {setStatements} WHERE Id = @Id";
        
        await _dbConnection.ExecuteAsync(sql, entity);
    }

    public async Task DeleteAsync(int id)
    {
        var sql = $"DELETE FROM {_tableName} WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}
