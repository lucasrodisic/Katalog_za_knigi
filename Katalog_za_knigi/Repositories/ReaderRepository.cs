using Katalog_za_knigi.Data;
using Katalog_za_knigi.Data.Entities;
using Katalog_za_knigi.Repositories.Abstractions;

namespace Katalog_za_knigi.Repositories
{
    public class ReaderRepository(BookDbContext context) : CrudRepository<Reader>(context), IReaderRepository;
}
