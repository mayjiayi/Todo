using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  public class TodoTaskController : Controller
  {
    private readonly ApplicationDbContext _db;
    public TodoTaskController(ApplicationDbContext db)
    {
      _db = db;
    }
    public IActionResult Index()
    {
      List<TodoTask> objTodoTask = _db.TodoTasks.ToList();
      return View(objTodoTask);
    }

    public IActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public IActionResult Create(TodoTask obj)
    {
      if (ModelState.IsValid) 
      {
        _db.TodoTasks.Add(obj);
        _db.SaveChanges();
        TempData["success"] = "Task created successfully";
        return RedirectToAction("Index", "TodoTask");
      }
      
      return View();
    }

    public IActionResult Edit(int? id)
    {
      if(id==null || id==0)
      {
        return NotFound();
      }

      TodoTask? taskFromDb = _db.TodoTasks.Find(id);
      if (taskFromDb == null)
      {
        return NotFound();
      }

      return View(taskFromDb);
    }
    
    [HttpPost]
    public IActionResult Edit(TodoTask obj)
    {
      if (ModelState.IsValid) 
      {
        _db.TodoTasks.Update(obj);
        _db.SaveChanges();
        TempData["success"] = "List updated successfully";
        return RedirectToAction("Index", "TodoTask");
      }
      
      return View();
    }

    public IActionResult Delete(int? id)
    {
      if(id==null || id==0)
      {
        return NotFound();
      }

      TodoTask? taskFromDb = _db.TodoTasks.Find(id);
      if (taskFromDb == null)
      {
        return NotFound();
      }

      return View(taskFromDb);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
      TodoTask? obj = _db.TodoTasks.Find(id); 
      if (obj == null)
      {
        return NotFound();
      }
      _db.TodoTasks.Remove(obj);
      _db.SaveChanges();
      TempData["success"] = "List deleted successfully";
      return RedirectToAction("Index", "TodoTask");
      
    }
  }
}