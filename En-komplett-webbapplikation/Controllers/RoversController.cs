using AutoMapper;
using En_komplett_webbapplikation.Domain.Models;
using En_komplett_webbapplikation.Domain.Services;
using En_komplett_webbapplikation.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace En_komplett_webbapplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoversController : Controller
    {
        private readonly IRoverService _roverService;
        private readonly IMapper _mapper;

        public RoversController(IRoverService roverService, IMapper mapper)
        {
            _roverService = roverService;
            _mapper = mapper;
        }

        // GET: api/Rovers
        [HttpGet]
        public async Task<IEnumerable<RoverResource>> GetRoversAsync()
        {
            var rovers = await _roverService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Rover>, IEnumerable<RoverResource>>(rovers);

            return resources;
        }

        // GET: api/Rovers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<RoverResource>> GetRover(int id)
        {
            var rover = await _roverService.GetRoverByIdAsync(id);
            var resource = _mapper.Map<Rover, RoverResource>(rover);

            if (rover == null)
            {
                return NotFound();
            }

            return resource;
        }
    }
}
