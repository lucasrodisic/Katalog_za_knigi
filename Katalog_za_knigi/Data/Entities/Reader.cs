using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Katalog_za_knigi.Data.Entities
{
    public class Reader : BaseEntity
    {

        [Required]
        [Unicode]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; } = null!;

        public bool IsStudent { get; set; }

        public virtual ICollection<BooksReaders> Books { get; set; } = new HashSet<BooksReaders>();
    }
}