using System.ComponentModel.DataAnnotations.Schema;

namespace RiverCitySyndicate.API.Data.Entities;


[Table("Songs")]
public class Song
{
    public Song()
    {
        Title = string.Empty;
        Artist = string.Empty;
        Active = true;
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public string Artist { get; set; }

    public bool Active { get; set; }

    public DateTime Added { get; set; }
}