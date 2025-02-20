using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katalog_za_knigi.Data.Entities
{
    public class BooksReaders
    {
        [Key]
        [Column(Order = 0)]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; } = null!;

        [Key]
        [Column(Order = 1)]
        public int ReaderId { get; set; }

        [ForeignKey(nameof(ReaderId))]
        public virtual Reader Reader { get; set; } = null!;
    }
}