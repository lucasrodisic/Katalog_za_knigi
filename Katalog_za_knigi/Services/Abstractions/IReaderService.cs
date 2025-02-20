using Katalog_za_knigi.DTOs;

namespace Katalog_za_knigi.Services.Abstractions
{
    public interface IReaderService
    {
        Task<ReaderDTO> GetByIdAsync(int id);
        Task<ICollection<ReaderDTO>> GetAllAsync();
        Task CreateAsync(ReaderDTO reader);
        Task UpdateAsync(ReaderDTO reader);
        Task DeleteAsync(int id);
        ICollection<ReaderDTO> GetByName(string name);
    }
}
