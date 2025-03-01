using System.ComponentModel.DataAnnotations;

namespace MonterdeNote.Server.Shared.DTOs
{
    public class NoteDto
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NoteCreationDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
    }

    public class NoteUpdateDto
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
