using MonterdeNote.Server.Core.Repositories;
using MonterdeNote.Server.Data;
using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppContext _context;
        public NoteRepository(AppContext appContext) {

            _context = appContext;
        }
        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task Get()
        {
            throw new NotImplementedException();
        }

        public Task GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task Post(NoteCreationDto noteCreationDto)
        {
            throw new NotImplementedException();
        }
    }
}
