namespace MVC.Models;

public class TodoModel
{
    public int Id { get; set; }
    public string? todoName { get; set; }
    public string? todoDescription { get; set; }
    public bool todoStatus { get; set; }
    
}