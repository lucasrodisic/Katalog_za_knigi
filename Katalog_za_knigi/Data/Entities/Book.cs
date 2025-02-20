using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katalog_za_knigi.Data.Entities
{
    public class Book : BaseEntity
    {

        [Required]
        [MaxLength(100)]
        [Unicode]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [Unicode]
        public string Author { get; set; } = null!;

        [Required]
        [Range(0.01, 10000, ErrorMessage = "Price must be between $0.01 and $10,000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Unicode]
        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Url]
        [MaxLength(500, ErrorMessage = "Image URL cannot exceed 500 characters.")]
        public string? ImageUrl { get; set; }

        public int? CategoryId { get; set; } = null;

        [ForeignKey(nameof(CategoryId))]
        public virtual Category? Category { get; set; } = null;

        public virtual ICollection<BooksReaders> Readers { get; set; } = new HashSet<BooksReaders>();

    }
}