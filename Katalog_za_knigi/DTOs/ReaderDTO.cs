using Katalog_za_knigi.Data.Entities;

namespace Katalog_za_knigi.DTOs
{
    public class ReaderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsStudent { get; set; }
        public virtual ICollection<BooksReaders> Books { get; set; } = new HashSet<BooksReaders>();
    }
}
