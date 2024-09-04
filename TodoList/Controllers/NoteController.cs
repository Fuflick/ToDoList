using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.DAL;
using TodoList.Domain;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private static MyDbContext _dbContext = new MyDbContext();
        
        [HttpGet]
        public async Task GetAllNotes()
        {
            var notes = await _dbContext.Notes.ToListAsync();
            await Response.WriteAsJsonAsync(notes);
        }

        [HttpPost]
        public async Task CreateNote()
        {
            var note = new Note(){Title = "test"};
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            await Response.WriteAsJsonAsync(Ok());
        }

        [HttpPatch]
        public async Task UpdateNote(int id, [FromBody] Note note)
        {
            try
            {
                var excitingNote = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
                if (excitingNote != null)
                {
                    await excitingNote.Update(note);
                    _dbContext.Notes.Update(excitingNote);
                    await _dbContext.SaveChangesAsync();
                    await Response.WriteAsJsonAsync(Ok(excitingNote));
                }
                else
                {
                    Response.StatusCode = 404;
                    await Response.WriteAsJsonAsync(new { message = "Not Foud" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Response.StatusCode = 500;
                await Response.WriteAsJsonAsync(new { message = "Internal error" });
            }
        }
    }
}
