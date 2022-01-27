using AutoMapper;
using En_komplett_webbapplikation.Domain.Models;
using En_komplett_webbapplikation.Resources;

namespace En_komplett_webbapplikation.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            this.CreateMap<Rover, RoverResource>();
        }
    }
}
