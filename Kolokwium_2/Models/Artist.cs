using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_2.Models;

[Table("Artist")]
public class Artist
{
    
    [Key]
    public int ArtistId { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]
    public string LastName { get; set; }
    public DateTime BirthDate { get; set;}
    
    //Map
    public virtual ICollection<Artwork> Artworks { get; set;}
}