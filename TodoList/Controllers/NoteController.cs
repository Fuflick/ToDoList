using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.DAL;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class NoteController : ControllerBase
    {
        private MyDbContext _dbContext;

        NoteController()
        {
            _dbContext = new MyDbContext();
        }
        
        [HttpPost]
        public async Task CreateNote()
        {
            var note = new Note();
            note.Name = $"test{note.Id}";
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            await Response.WriteAsJsonAsync(note);
        }

        [HttpGet]
        public async Task GetAll()
        {
            var list = await _dbContext.Notes.ToListAsync();
            await Response.WriteAsJsonAsync(list);
        }
    }
}
