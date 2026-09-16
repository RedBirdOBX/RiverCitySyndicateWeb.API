using AutoMapper;
using RiverCitySyndicate.APi.Service;
using RiverCitySyndicate.API.Dtos;
using RiverCitySyndicate.API.Dtos.Filters;
using RiverCitySyndicate.API.Web.Controllers.ResponseHelpers;
using Microsoft.AspNetCore.Mvc;

namespace RiverCitySyndicate.API.Web.Controllers;

/// <summary>
/// SongsController
/// </summary>
[Route("api/songs")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class SongsController : ControllerBase
{

    private readonly ILogger<SongsController> _logger;
    private readonly ISongProcessor _processor;
    private readonly IMapper _mapper;

    /// <summary>
    /// Constructor
    /// </summary>
    public SongsController(ISongProcessor processor, IMapper mapper, ILogger<SongsController> logger)
    {
        _processor = processor ?? throw new ArgumentNullException(nameof(ISongProcessor));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(Mapper));
        _logger = logger;
    }

    /// <summary>
    /// returns collection of all songs
    /// </summary>
    /// <returns>collection of songs</returns>
    /// <example>{baseUrl}/api/songs</example>
    /// <response code="200">returns collection of songs</response>
    [HttpGet("", Name = "GetSongs")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SongDto>>> GetSongs()
    {
        try
        {
            _logger.LogInformation("Getting Songs data.");

            var songsDtos = await _processor.GetSongsAsync();
            return Ok(songsDtos);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error in {nameof(GetSongs)}: {ex}");
            return StatusCode(500, "An application error occurred.");
        }
    }
}
