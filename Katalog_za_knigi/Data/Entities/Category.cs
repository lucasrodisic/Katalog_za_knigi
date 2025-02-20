using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Katalog_za_knigi.Data.Entities
{
    public class Category : BaseEntity
    {

        [Required]
        [MaxLength(100)]
        [Unicode]
        public string Name { get; set; } = null!;
        public virtual ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}