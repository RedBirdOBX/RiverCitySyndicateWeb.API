using AutoMapper;
using RiverCitySyndicate.API.Data.Entities;
using RiverCitySyndicate.API.Dtos;

namespace RiverCitySyndicate.API.Web.AutoMapperProfiles;

public class ShowProfile : Profile
{
    public ShowProfile()
    {
        // source, destination
        CreateMap<Show?, ShowDto>();
    }
}
