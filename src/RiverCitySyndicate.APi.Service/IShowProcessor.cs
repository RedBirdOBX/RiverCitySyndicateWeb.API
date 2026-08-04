using RiverCitySyndicate.API.Dtos;
using RiverCitySyndicate.API.Dtos.Filters;

namespace RiverCitySyndicate.APi.Service;

public interface IShowProcessor
{
    /// <summary>
    /// gets a single show
    /// </summary>
    /// <param name="showId"></param>
    /// <returns>ShowDto</returns>
    Task<ShowDto?> GetShowAsync(int showId);

    /// <summary>
    /// gets a single show by slug
    /// </summary>
    /// <param name="slug"></param>
    /// <returns>ShowDto</returns>
    Task<ShowDto?> GetShowBySlugAsync(string slug);

    /// <summary>
    /// returns a list of shows
    /// </summary>
    /// <returns>collection of ShowDtos</returns>
    Task<IEnumerable<ShowDto>> GetShowsAsync();

    /// <summary>
    /// returns a list of filtered shows
    /// </summary>
    /// <param name="filter"></param>
    /// <returns>collection of ShowDtos</returns>
    Task<IEnumerable<ShowDto>> GetShowsFilteredAsync(ShowFilter filter);

    /// <summary>
    /// Gets the next upcoming show
    /// </summary>
    /// <returns>ShowDto</returns>
    Task<ShowDto?> GetNextShowAsync();

    /// <summary>
    /// checks to see if showId is legit
    /// </summary>
    /// <param name="showId"></param>
    /// <returns>bool</returns>
    Task<bool> DoesShowExistAsync(int showId);

    /// <summary>
    /// checks to see if slug is legit
    /// </summary>
    /// <param name="slug"></param>
    /// <returns>bool</returns>
    Task<bool> DoesShowExistBySlugAsync(string slug);
}
