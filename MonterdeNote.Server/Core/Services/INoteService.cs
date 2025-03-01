using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Core.Services
{
    public interface INoteService
    {
        Task Get();
        Task GetById(Guid guid);
        Task Post(NoteCreationDto noteCreationDto);
        Task Delete(Guid guid);
    }
}
