using RiverCitySyndicate.API.Dtos;

namespace RiverCitySyndicate.APi.Service;

public interface ISongProcessor
{
    /// <summary>
    /// returns a list of songs
    /// </summary>
    /// <returns>collection of SongDtos</returns>
    Task<IEnumerable<SongDto>> GetSongsAsync();
}
