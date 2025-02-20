using Katalog_za_knigi.Data.Entities;

namespace Katalog_za_knigi.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
