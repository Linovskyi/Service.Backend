using AutoMapper;
using DogsService.Application.Common.Mappings;
using DogsService.Domain;

namespace DogsService.Application.Dogs.Queries.GetDogDetails
{
    public class DogDetailsVm : IMapWith<Dog>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dog, DogDetailsVm>()
                .ForMember(dogVm => dogVm.Id, opt => opt.MapFrom(dog => dog.Id))
                .ForMember(dogVm => dogVm.Name, opt => opt.MapFrom(dog => dog.Name))
                .ForMember(dogVm => dogVm.Color, opt => opt.MapFrom(dog => dog.Color))
                .ForMember(dogVm => dogVm.TailLength, opt => opt.MapFrom(dog => dog.TailLength))
                .ForMember(dogVm => dogVm.Weight, opt => opt.MapFrom(dog => dog.Weight));
        }
    }
}