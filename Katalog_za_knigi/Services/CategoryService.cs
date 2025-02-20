using AutoMapper;
using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.DTOs;
using Katalog_za_knigi.Repositories.Abstractions;
using Katalog_za_knigi.Services.Abstractions;

namespace Katalog_za_knigi.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<CategoryDTO>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<ICollection<CategoryDTO>>(categories);
        }

        public async Task CreateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }
        public ICollection<CategoryDTO> GetByName(string name)
        {
            var categories = _categoryRepository.GetByFilter(x => x.Name.Equals(name));
            return _mapper.Map<ICollection<CategoryDTO>>(categories); 
        }

        public async Task UpdateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteByIdAsync(id);
        }

    }
}
