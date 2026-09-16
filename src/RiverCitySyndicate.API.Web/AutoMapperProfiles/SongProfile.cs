using AutoMapper;
using RiverCitySyndicate.API.Data.Entities;
using RiverCitySyndicate.API.Dtos;

namespace RiverCitySyndicate.API.Web.AutoMapperProfiles;

public class SongProfile : Profile
{
    public SongProfile()
    {
        // source, destination
        CreateMap<Song?, SongDto>();
    }
}
