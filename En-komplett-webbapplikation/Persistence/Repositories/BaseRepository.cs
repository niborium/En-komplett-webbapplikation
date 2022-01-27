using En_komplett_webbapplikation.Persistence.Contexts;

namespace En_komplett_webbapplikation.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
