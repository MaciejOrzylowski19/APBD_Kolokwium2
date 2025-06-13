using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_2.Models;

[Table("Artwork")]
public class Artwork
{
    [Key]
    public int ArtworkId { get; set; }
    [ForeignKey(nameof(Artist))]
    public int ArtistId { get; set; }
    [MaxLength(100)]
    public string Title { get; set; }
    public int YearCreated { get; set; }
    
    //map
    public virtual Artist Artist { get; set; }
    public virtual ICollection<ExhibitionArtwork> ExhibitionArtworks { get; set;}
    
}