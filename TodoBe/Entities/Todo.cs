using System.ComponentModel.DataAnnotations;

namespace TodoBe.Entities;

public class Todo
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public bool Completed { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}