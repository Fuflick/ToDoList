using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        [HttpGet]
        public async Task CreateNote()
        {
            var note = new Note();
            note.Name = "test";
            await Response.WriteAsJsonAsync(note);
        }
    }
}
