using System.Text.Json;
using AutoMapper;
using TableTennis4dView.Application.DTOs.CameraView;
using TableTennis4dView.Application.DTOs.Player;
using TableTennis4dView.Application.DTOs.Technique;
using TableTennis4dView.Core.Entities;

namespace TableTennis4dView.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ConfigureCameraView();
            ConfigureTechnique();
            ConfigurePlayer();
        }

        private void ConfigureCameraView()
        {
            CreateMap<CameraView, CameraViewDto>()
                .ForMember(dest => dest.ParsedImages, opt => opt.MapFrom(src => JsonSerializer.Deserialize<List<string>>(src.Resource, (JsonSerializerOptions)null!)));
        }

        private void ConfigureTechnique() {
            CreateMap<Technique, TechniqueDtoSlim>();
            CreateMap<Technique, TechniqueDto>();
        }

        private void ConfigurePlayer() {
            CreateMap<Player, PlayerDtoSlim>(MemberList.None)
                .ForMember(d => d.TechniqueCount, opt => opt.MapFrom(src => src.Techniques.Count));
            CreateMap<Player, PlayerDto>()
                .ForMember(d => d.TechniqueCount, opt => opt.MapFrom(src => src.Techniques.Count));
        }
    }
}
