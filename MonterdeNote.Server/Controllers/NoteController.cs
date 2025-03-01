using Microsoft.AspNetCore.Mvc;
using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        public NoteController() {
        
        
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Post([FromBody] NoteCreationDto noteCreationDto)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            return Ok();

        }
    }
}
