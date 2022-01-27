using En_komplett_webbapplikation.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace En_komplett_webbapplikation.Domain.Repositories
{
    public interface IRoverRepository
    {
        Task<IEnumerable<Rover>> ListAsync();
        Task<Rover> GetRoverByIdAsync(int id);
    }
}
