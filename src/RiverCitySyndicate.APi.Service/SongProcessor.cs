using AutoMapper;
using Microsoft.Extensions.Logging;
using RiverCitySyndicate.API.Data.Repositories;
using RiverCitySyndicate.API.Dtos;

namespace RiverCitySyndicate.APi.Service;

public class SongProcessor : ISongProcessor
{
    private IRiverCitySyndicateRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<SongProcessor> _logger;

    public SongProcessor(IRiverCitySyndicateRepository repository, IMapper mapper, ILogger<SongProcessor> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(IRiverCitySyndicateRepository));
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// returns a list of songs
    /// </summary>
    /// <returns>collection of SongDtos</returns>
    public async Task<IEnumerable<SongDto>> GetSongsAsync()
    {
        try
        {
            var songs = await _repository.GetSongsAsync(showAll: true);
            var results = _mapper.Map<IEnumerable<SongDto>>(songs);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {nameof(GetSongsAsync)}", ex);
            throw ex;
        }
    }
}