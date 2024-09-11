using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TodoList.Domain;

public class Note
{
    [Key] public int Id { get; private set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    
    public DateTime? CreationTime { get; set; } //Todo: fix autoupdate after docker-compose restart

   public DateTime? LastUpdated { get; set; }

    public Note()
    {
        Title = "New Note";
        CreationTime = LastUpdated = DateTime.Now.ToUniversalTime();
    }

    public async Task Update(Note note)
    {
        this.Title = note.Title;
        this.Body = note.Body;
        LastUpdated = DateTime.Now.ToUniversalTime();
    }
}