using MonterdeNote.Server.Core.Models;
using MonterdeNote.Server.Core.Repositories;
using MonterdeNote.Server.Data;
using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;
        public NoteRepository(AppDbContext appContext) {

            _context = appContext;
        }
        public async Task Delete(Guid guid)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Guid == guid);
            if (note == null)
            {
                throw new Exception("Note not found");
            }
            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public Task<IQueryable<NoteDto>> Get()
        {
            var notes = _context.Notes.Select(x => new NoteDto
            {
                Guid = x.Guid,
                Title = x.Title,
                Content = x.Content
            });
            return Task.FromResult(notes);
        }

        public Task<NoteDto> GetById(Guid guid)
        {
            var note = _context.Notes.FirstOrDefault(x => x.Guid == guid);
            if (note == null)
            {
                throw new Exception("Note not found");
            }
            return Task.FromResult(new NoteDto
            {
                Guid = note.Guid,
                Title = note.Title,
                Content = note.Content
            });
        }

        public Task Post(Note noteCreation)
        {
            _context.Notes.Add(noteCreation);
            return _context.SaveChangesAsync();
        }
    }
}
