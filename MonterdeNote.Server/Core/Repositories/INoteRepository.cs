using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Core.Repositories
{
    public interface INoteRepository
    {
        Task Get();
        Task GetById(Guid guid);
        Task Post(NoteCreationDto noteCreationDto);
        Task Delete(Guid guid);
    }
}
