using AutoMapper;
using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.DTOs;
using Katalog_za_knigi.Repositories.Abstractions;
using Katalog_za_knigi.Services.Abstractions;

namespace Katalog_za_knigi.Services
{
    public class BookService(IBookRepository bookRepository, IMapper mapper) : IBookService
    {
        private readonly IBookRepository _bookRepository = bookRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ICollection<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<ICollection<BookDTO>>(books);
        }

        public async Task CreateAsync(BookDTO book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            await _bookRepository.CreateAsync(bookEntity);
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookDTO>(book);
        }

        public ICollection<BookDTO> GetByTitle(string title)
        {
            var books = _bookRepository.GetByFilter(x => x.Title.Equals(title));
            return _mapper.Map<ICollection<BookDTO>>(books); 
        }
        public async Task UpdateAsync(BookDTO book)
        {
            var bookEntity = _mapper.Map<Book>(book);
            await _bookRepository.UpdateAsync(bookEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteByIdAsync(id);
        }
    }
}
