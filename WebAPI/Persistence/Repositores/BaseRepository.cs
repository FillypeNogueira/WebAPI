using WebAPI.Persistence.Context;

namespace WebAPI.Persistence.Repositores
{
    public abstract class BaseRepository
    {
        private readonly DataAppDbContext _context;

        protected BaseRepository(DataAppDbContext context)
        {
            _context = context;
        }
    }
}
