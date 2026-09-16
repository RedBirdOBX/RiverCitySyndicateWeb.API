namespace RiverCitySyndicate.API.Dtos;

public class SongDto
{
    public SongDto()
    {
        Title = string.Empty;
        Artist = string.Empty;
        Active = true;
    }

    /// <summary>
    /// Id of song
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of song
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Artist of the song
    /// </summary>
    public string Artist { get; set; }

    /// <summary>
    /// Active bool
    /// </summary>
    public bool Active { get; set; }

    /// <summary>
    /// Date record was added
    /// </summary>
    public DateTime Added { get; set; }
}