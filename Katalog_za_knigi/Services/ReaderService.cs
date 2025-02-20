using AutoMapper;
using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.DTOs;
using Katalog_za_knigi.Repositories.Abstractions;
using Katalog_za_knigi.Repositories;
using Katalog_za_knigi.Services.Abstractions;

namespace Katalog_za_knigi.Services
{
    public class ReaderService(IReaderRepository readerRepository, IMapper mapper) : IReaderService
    {
        private readonly IReaderRepository _readerRepository = readerRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<ReaderDTO>> GetAllAsync()
        {
            var readers = await _readerRepository.GetAllAsync();
            return _mapper.Map<ICollection<ReaderDTO>>(readers);
        }

        public async Task CreateAsync(ReaderDTO reader)
        {
            var readerEntity = _mapper.Map<Reader>(reader);
            await _readerRepository.CreateAsync(readerEntity);
        }

        public async Task<ReaderDTO> GetByIdAsync(int id)
        {
            var reader = await _readerRepository.GetByIdAsync(id);
            return _mapper.Map<ReaderDTO>(reader);
        }
        public ICollection<ReaderDTO> GetByName(string name)
        {
            var readers = _readerRepository.GetByFilter(x => x.Name.Equals(name));
            return _mapper.Map<ICollection<ReaderDTO>>(readers); 
        }

        public async Task UpdateAsync(ReaderDTO reader)
        {
            var readerEntity = _mapper.Map<Reader>(reader);
            await _readerRepository.UpdateAsync(readerEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _readerRepository.DeleteByIdAsync(id);
        }

    }
}
