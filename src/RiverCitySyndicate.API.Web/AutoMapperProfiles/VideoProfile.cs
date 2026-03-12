using AutoMapper;
using RiverCitySyndicate.API.Data.Entities;
using RiverCitySyndicate.API.Dtos;

namespace RiverCitySyndicate.API.Web.AutoMapperProfiles;

public class VideoProfile : Profile
{
    public VideoProfile()
    {
        // source, destination
        CreateMap<Video?, VideoDto>();
    }
}
