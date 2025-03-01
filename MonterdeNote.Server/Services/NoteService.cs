using MonterdeNote.Server.Core.Models;
using MonterdeNote.Server.Core.Repositories;
using MonterdeNote.Server.Core.Services;
using MonterdeNote.Server.Shared.DTOs;

namespace MonterdeNote.Server.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        public NoteService(INoteRepository noteRepository) {
            _noteRepository = noteRepository;
        }
        public async Task Delete(Guid guid)
        {
            var existingNote = await _noteRepository.GetById(guid);
            if (existingNote == null)
            {
                throw new Exception("Note not found");
            }
            await _noteRepository.Delete(guid);
        }

        public async Task<List<NoteDto>> Get()
        {
            var notes = await _noteRepository.Get();
            return notes.Select(note => new NoteDto
            {
                Guid = note.Guid,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt,
            }).ToList();
        }

        public async Task<NoteDto> GetById(Guid guid)
        {
            var note = await _noteRepository.GetById(guid);
            if (note == null)
            {
                throw new Exception("Note not found");
            }
            return new NoteDto
            {
                Guid = note.Guid,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt,
            };
        }

        public Task Post(NoteCreationDto noteCreationDto)
        {
            var note = new Note
            {
                Guid = Guid.NewGuid(),
                Title = noteCreationDto.Title,
                Content = noteCreationDto.Content,
                CreatedAt = DateTime.UtcNow,
            };
            return _noteRepository.Post(note);
        }
    }
}
