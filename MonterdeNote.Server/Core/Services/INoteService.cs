using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Core.Services
{
    public interface INoteService
    {
        Task<List<NoteDto>> Get();
        Task<NoteDto> GetById(Guid guid);
        Task Post(NoteCreationDto noteCreationDto);
        Task Delete(Guid guid);
    }
}
