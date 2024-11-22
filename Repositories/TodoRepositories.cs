using MVC.Models;

namespace MVC.Repositories;

public class TodoRepositories : GenericRepository<TodoModel>, ITodoRepositories
{
    public TodoRepositories(IConfiguration configuration) : base(configuration)
    {
    }
}