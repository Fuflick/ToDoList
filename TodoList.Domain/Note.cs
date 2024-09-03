using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain;

public class Note
{
    [Key] public int Id { get; private set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    
    public DateTime CreationTime { get; } = DateTime.Now;
}