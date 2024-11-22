using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers;

public class TodoController(ITodoService todoService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        return View(await todoService.GetAllAsync());
    }
    //get
    public IActionResult Create()
    {
        return View();
    }
    
    
    // POST
    [HttpPost]
    public async Task<IActionResult> Create(TodoModel model)
    {
        await todoService.AddAsync(model);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Update(int id)
    {
        return View(await todoService.GetByIdAsync(id));
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(TodoModel model)
    {
        await todoService.UpdateAsync(model);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Delete(int id)
    {
        await todoService.DeleteAsync(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await todoService.GetByIdAsync(id));
    }
    
    public async Task<IActionResult> MarkAsComplete(int id)
    {
        todoService.MarkAsComplete(id);
        return RedirectToAction("Index");
    }
}