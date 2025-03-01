using MonterdeNote.Server.Core.Models;
using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Core.Repositories
{
    public interface INoteRepository
    {
        Task<IQueryable<NoteDto>> Get();
        Task<NoteDto> GetById(Guid guid);
        Task Post(Note noteCreationDto);
        Task Delete(Guid guid);
    }
}
