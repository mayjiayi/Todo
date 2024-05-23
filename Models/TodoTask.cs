using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
  public class TodoTask
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Task Name")]
    public string Name { get; set; }

    public int TodoListId { get; set; }
    [ForeignKey("TodoListId")]
    public TodoList TodoList { get; set; }
  }
}