using En_komplett_webbapplikation.Domain.Models;
using En_komplett_webbapplikation.Domain.Repositories;
using En_komplett_webbapplikation.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace En_komplett_webbapplikation.Services
{
    public class RoverService : IRoverService
    {
        private readonly IRoverRepository _roverRepository;

        public RoverService(IRoverRepository roverRepository)
        {
            _roverRepository = roverRepository;
        }

        public async Task<Rover> GetRoverByIdAsync(int id)
        {
            return await _roverRepository.GetRoverByIdAsync(id);
        }

        public async Task<IEnumerable<Rover>> ListAsync()
        {
            return await _roverRepository.ListAsync();
        }
    }
}
