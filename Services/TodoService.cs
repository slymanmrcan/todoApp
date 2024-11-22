using System.Data;
using System.Data.SqlClient;
using Dapper;
using MVC.Models;
using MVC.Repositories;

namespace MVC.Services;

public class TodoService(IGenericRepository<TodoModel> repository) : GenericService<TodoModel>(repository), ITodoService
{
    public async Task<int> MarkAsComplete(int id)
    {
        var data =await repository.GetByIdAsync(id);
        data.todoStatus =true;
        var update  = repository.UpdateAsync(data);
        return 1;
    }
}



