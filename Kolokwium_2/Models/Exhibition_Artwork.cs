using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.Models;

[Table("ExhibitionArtwork")]
[PrimaryKey(nameof(ArtworkId), nameof(ExhibitionId))]
public class ExhibitionArtwork
{
    
    [ForeignKey(nameof(Exhibition))]
    public int ExhibitionId { get; set; }
    
    [ForeignKey(nameof(Artwork))]
    public int ArtworkId { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public Decimal InsuranceValue { get; set; }
    
    //map
    public virtual Artwork Artwork { get; set;}
    public virtual Exhibition Exhibition { get; set;}
    
}