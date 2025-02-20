using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Katalog_za_knigi.Data
{
    public class BookDbContext : IdentityDbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Reader> Readers { get; set; } = default!;
        public DbSet<BooksReaders> BooksReaders { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksReaders>()
                .HasKey(br => new { br.BookId, br.ReaderId });

            modelBuilder.Entity<BooksReaders>()
                .HasOne(br => br.Book)
                .WithMany(b => b.Readers)
                .HasForeignKey(br => br.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BooksReaders>()
                .HasOne(br => br.Reader)
                .WithMany(r => r.Books)
                .HasForeignKey(br => br.ReaderId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }

}
