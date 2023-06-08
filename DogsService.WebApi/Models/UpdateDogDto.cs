using AutoMapper;
using DogsService.Application.Common.Mappings;
using DogsService.Application.Dogs.Commands.CreateDog;
using DogsService.Application.Dogs.Commands.UpdateDog;

namespace DogsService.WebApi.Models
{
    public class UpdateDogDto : IMapWith<UpdateDogCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDogDto, UpdateDogCommand>()
                .ForMember(dogCommand => dogCommand.Id,
                    opt => opt.MapFrom(dogDto => dogDto.Id))
                .ForMember(dogCommand => dogCommand.Name,
                    opt => opt.MapFrom(dogDto => dogDto.Name))
                .ForMember(dogCommand => dogCommand.Color,
                    opt => opt.MapFrom(dogDto => dogDto.Color))
                .ForMember(dogCommand => dogCommand.TailLength,
                    opt => opt.MapFrom(dogDto => dogDto.TailLength))
                .ForMember(dogCommand => dogCommand.Weight,
                    opt => opt.MapFrom(dogDto => dogDto.Weight));
        }
    }
}
