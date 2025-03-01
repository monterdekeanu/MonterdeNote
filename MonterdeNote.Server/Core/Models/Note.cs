using System.ComponentModel.DataAnnotations;

namespace MonterdeNote.Server.Core.Models
{
    public class Note
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
