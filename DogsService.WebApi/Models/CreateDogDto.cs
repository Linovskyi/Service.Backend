using AutoMapper;
using DogsService.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;
using DogsService.Application.Dogs.Commands.CreateDog;

namespace DogsService.WebApi.Models
{
    public class CreateDogDto : IMapWith<CreateDogCommand>
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }
        public int TailLength { get; set; }
        public int Weight { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDogDto, CreateDogCommand>()
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