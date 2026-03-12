using AutoMapper;
using Microsoft.Extensions.Logging;
using RiverCitySyndicate.API.Data.Repositories;
using RiverCitySyndicate.API.Dtos;
using RiverCitySyndicate.API.Dtos.Filters;

namespace RiverCitySyndicate.APi.Service;

public class ShowProcessor : IShowProcessor
{
    private IRiverCitySyndicateRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILogger<ShowProcessor> _logger;

    public ShowProcessor(IRiverCitySyndicateRepository repository, IMapper mapper, ILogger<ShowProcessor> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(IRiverCitySyndicateRepository));
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// returns a list of shows
    /// </summary>
    /// <returns>collection of ShowDtos</returns>
    public async Task<IEnumerable<ShowDto>> GetShowsAsync()
    {
        try
        {
            var shows = await _repository.GetShowsAsync();
            var results = _mapper.Map<IEnumerable<ShowDto>>(shows);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {nameof(GetShowsAsync)}", ex);
            throw ex;
        }
    }

    /// <summary>
    /// returns a filtered list of shows
    /// </summary>
    /// <param name="filter"></param>
    /// <returns>collection of ShowDtos</returns>
    public async Task<IEnumerable<ShowDto>> GetShowsFilteredAsync(ShowFilter filter)
    {
        try
        {
            var shows = await _repository.GetShowsFilteredAsync(filter);
            var results = _mapper.Map<IEnumerable<ShowDto>>(shows);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {nameof(GetShowsFilteredAsync)}", ex);
            throw ex;
        }
    }

    /// <summary>
    /// gets single show
    /// </summary>
    /// <param name="showId"></param>
    /// <returns>ShotDto</returns>
    public async Task<ShowDto?> GetShowAsync(int showId)
    {
        try
        {
            var show = await _repository.GetShowAsync(showId);

            var results = _mapper.Map<ShowDto>(show);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {nameof(GetShowAsync)}", ex);
            throw;
        }
    }

    /// <summary>
    /// gets next upcoming show
    /// </summary>
    /// <returns>ShowDto</returns>
    public async Task<ShowDto?> GetNextShowAsync()
    {
        try
        {
            var show = await _repository.GetNextShowAsync();
            var results = _mapper.Map<ShowDto>(show);
            return results;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {nameof(GetNextShowAsync)}", ex);
            throw;
        }
    }

    /// <summary>
    /// checks to see if showId is legit
    /// </summary>
    /// <param name="showId"></param>
    /// <returns>bool</returns>
    public async Task<bool> DoesShowExistAsync(int showId)
    {
        return await _repository.DoesShowExistAsync(showId);
    }
}