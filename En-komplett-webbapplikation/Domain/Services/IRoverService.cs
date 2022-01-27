using En_komplett_webbapplikation.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace En_komplett_webbapplikation.Domain.Services
{
    public interface IRoverService
    {
        Task<IEnumerable<Rover>> ListAsync();
        Task<Rover> GetRoverByIdAsync(int id);
    }
}
