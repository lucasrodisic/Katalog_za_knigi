using Katalog_za_knigi.DTOs;

namespace Katalog_za_knigi.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<CategoryDTO> GetByIdAsync(int id);
        Task<ICollection<CategoryDTO>> GetAllAsync();
        Task CreateAsync(CategoryDTO category);
        Task UpdateAsync(CategoryDTO category);
        Task DeleteAsync(int id);
        ICollection<CategoryDTO> GetByName(string name);
    }
}
