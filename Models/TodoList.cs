using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
  public class TodoList
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("List Name")]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(0,100)]
    public int DisplayOrder { get; set; }
  }
}