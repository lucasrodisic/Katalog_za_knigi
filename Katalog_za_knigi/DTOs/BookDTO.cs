using System.ComponentModel.DataAnnotations;
using Katalog_za_knigi.Data.Entities;

namespace Katalog_za_knigi.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        [Display(Name="Image")]
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public ICollection<CategoryDTO>? Categories { get; set; } = null!;
        public virtual ICollection<BooksReaders> Readers { get; set; } = new HashSet<BooksReaders>();
    }
}
