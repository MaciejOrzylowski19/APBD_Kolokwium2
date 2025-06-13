using Kolokwium_2.Models;

namespace Kolokwium_2.DTOs;

public class GalleryDTO
{
    public int GalleryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set;}
    public List<ExhibitionDTO> Exhibitions { get; set;}
}