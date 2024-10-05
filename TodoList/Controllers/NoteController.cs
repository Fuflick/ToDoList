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
            var note = new Note();
            await _dbContext.Notes.AddAsync(note);
            await _dbContext.SaveChangesAsync();
            await Response.WriteAsJsonAsync(Ok());
        }

        [HttpPatch]
        public async Task UpdateNote(int id, string title, string body)
        {
            try
            {
                var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);
                if (note != null)
                {
                    note.Title = title;
                    note.Body = body;
                    note.LastUpdated = DateTime.Now.ToUniversalTime();
                    _dbContext.Notes.Update(note);
                    await _dbContext.SaveChangesAsync();
                    await Response.WriteAsJsonAsync(Ok(note));
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

        [HttpDelete]
        public async Task DeleteNote(int? id)
        {
            try
            {
                var note = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == id);

                if (note != null)
                {
                    _dbContext.Notes.Remove(note);
                    await _dbContext.SaveChangesAsync();
                    await Response.WriteAsJsonAsync(note); // Todo: change note to statusCode 200
                }
                else
                {
                    Response.StatusCode = 404;
                }
            }
            catch (Exception ex)
            {
                await Response.WriteAsJsonAsync(new { message = $"{ex.Message}"});
            }
        }
    }
}
