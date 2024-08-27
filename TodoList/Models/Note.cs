using System.ComponentModel.DataAnnotations;

namespace TodoList;

public class Note
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Body { get; set; }

    public DateTime CreateionTime { get; set; } = DateTime.Now;

}