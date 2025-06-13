namespace Kolokwium_2.DTOs;

public class ArtworkDTO
{
    public string Title { get; set; }
    public int YearCreated { get; set; }
    public Decimal InsuranceValue { get; set; }
    public ArtistDTO Artist { get; set; }
}