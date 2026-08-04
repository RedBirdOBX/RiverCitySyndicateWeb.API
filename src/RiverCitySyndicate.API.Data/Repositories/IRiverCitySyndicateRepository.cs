using RiverCitySyndicate.API.Data.Entities;
using RiverCitySyndicate.API.Dtos.Filters;

namespace RiverCitySyndicate.API.Data.Repositories;

public interface IRiverCitySyndicateRepository
{
    // shows
    Task<IEnumerable<Show>> GetShowsAsync();

    Task<IEnumerable<Show>> GetShowsFilteredAsync(ShowFilter filter);

    Task<Show?> GetShowAsync(int showId);

    Task<Show?> GetShowBySlugAsync(string slug);

    Task<Show?> GetNextShowAsync();

    Task<bool> DoesShowExistAsync(int showId);

    Task<bool> DoesShowExistBySlugAsync(string slug);

    // photos
    Task<IEnumerable<Photo>> GetPhotosAsync(bool showAll);

    Task<Photo?> GetPhotoAsync(int photoId);

    Task<bool> DoesPhotoExistAsync(int photoId);

    // videos
    Task<IEnumerable<Video>> GetVideosAsync(bool showAll);

    Task<Video?> GetVideoAsync(int videoId);

    Task<bool> DoesVideoExistAsync(int videoId);
}
