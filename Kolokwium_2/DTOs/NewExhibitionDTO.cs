namespace Kolokwium_2.DTOs;

public class NewExhibitionDTO
{
    public string Title { get; set; }
    public string Gallery { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ArtworkAddDTO> Artworks { get; set; }
}