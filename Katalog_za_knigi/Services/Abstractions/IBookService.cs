using Katalog_za_knigi.DTOs;

namespace Katalog_za_knigi.Services.Abstractions
{
    public interface IBookService
    {
        Task<BookDTO> GetByIdAsync(int id);
        Task<ICollection<BookDTO>> GetAllAsync();
        Task CreateAsync(BookDTO book);
        Task UpdateAsync(BookDTO book);
        Task DeleteAsync(int id);
        ICollection<BookDTO> GetByTitle(string title);
    }
}
