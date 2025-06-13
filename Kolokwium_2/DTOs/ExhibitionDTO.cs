namespace Kolokwium_2.DTOs;

public class ExhibitionDTO
{
 
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int NumberOfArtworks { get; set; }
    public List<ArtworkDTO> Artworks { get; set; }
}