using Microsoft.AspNetCore.Mvc;
using MonterdeNote.Server.Core.Services;
using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _noteService;
        public NoteController(INoteService noteService) {
            _noteService = noteService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var notes = await _noteService.Get();
                return Ok(notes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NoteCreationDto noteCreationDto)
        {
            try
            {
                await _noteService.Post(noteCreationDto);
                return Ok("Note Added");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid guid)
        {
            try
            {
                await _noteService.Delete(guid);
                return Ok("Note Deleted");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
    }
}
