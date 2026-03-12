using AutoMapper;
using RiverCitySyndicate.API.Data.Entities;
using RiverCitySyndicate.API.Dtos;

namespace RiverCitySyndicate.API.Web.AutoMapperProfiles;

public class PhotoProfile : Profile
{
    public PhotoProfile()
    {
        // source, destination
        CreateMap<Photo?, PhotoDto>();
    }
}
