using Kolokwium_2.DTOs;
using Kolokwium_2.Models;

namespace Kolokwium_2.Services;

public interface IMuzeumService
{
    
    public Task<GalleryDTO> GetExhibitions(int galleryId);
    public Task<ExhibitStatus> AddExhibition(NewExhibitionDTO exhibition);
}