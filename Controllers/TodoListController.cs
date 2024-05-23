using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{
  public class TodoListController : Controller
  {
    private readonly ApplicationDbContext _db;
    public TodoListController(ApplicationDbContext db)
    {
      _db = db;
    }
    public IActionResult Index()
    {
      List<TodoList> objTodoLIst = _db.TodoLists.ToList();
      return View(objTodoLIst);
    }

    public IActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public IActionResult Create(TodoList obj)
    {
      if (obj.Name == obj.DisplayOrder.ToString())
      {
        ModelState.AddModelError("name", "The display order cannot exactly match the name.");
      }

      if (obj.Name.ToLower() == "test")
      {
        ModelState.AddModelError("", "Test is an invalid value");
      }

      if (ModelState.IsValid) 
      {
        _db.TodoLists.Add(obj);
        _db.SaveChanges();
        TempData["success"] = "List created successfully";
        return RedirectToAction("Index", "TodoList");
      }
      
      return View();
    }

    public IActionResult Edit(int? id)
    {
      if(id==null || id==0)
      {
        return NotFound();
      }

      TodoList? listFromDb = _db.TodoLists.Find(id);
      if (listFromDb == null)
      {
        return NotFound();
      }

      return View(listFromDb);
    }
    
    [HttpPost]
    public IActionResult Edit(TodoList obj)
    {
      if (ModelState.IsValid) 
      {
        _db.TodoLists.Update(obj);
        _db.SaveChanges();
        TempData["success"] = "List updated successfully";
        return RedirectToAction("Index", "TodoList");
      }
      
      return View();
    }

    public IActionResult Delete(int? id)
    {
      if(id==null || id==0)
      {
        return NotFound();
      }

      TodoList? listFromDb = _db.TodoLists.Find(id);
      if (listFromDb == null)
      {
        return NotFound();
      }

      return View(listFromDb);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? id)
    {
      TodoList? obj = _db.TodoLists.Find(id); 
      if (obj == null)
      {
        return NotFound();
      }
      _db.TodoLists.Remove(obj);
      _db.SaveChanges();
      TempData["success"] = "List deleted successfully";
      return RedirectToAction("Index", "TodoList");
      
    }
  }
}