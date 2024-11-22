using MVC.Models;

namespace MVC.Services;

public interface ITodoService:IGeneriService<TodoModel>
{
    Task<int> MarkAsComplete(int id);
}