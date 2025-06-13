using Kolokwium_2.DB;
using Kolokwium_2.DTOs;
using Kolokwium_2.Models;

namespace Kolokwium_2.Services;

public class MuzeumService : IMuzeumService
{

    private DatabaseContext context;

    public MuzeumService(DatabaseContext context)
    {
        this.context = context;
    }
    
    
    
    public async Task<GalleryDTO> GetExhibitions(int galleryId)
    {

        var gallery = context.Galleries.Where(a => a.GalleryId == galleryId).ToList()[0];

        GalleryDTO galleryDto = new GalleryDTO()
        {
            GalleryId = galleryId,
            Name = gallery.Name,
            EstablishedDate = gallery.EstablishedDate,
            Exhibitions = gallery.Exhibitions.Select(a => new ExhibitionDTO()
            {
                NumberOfArtworks = a.NumberOfArtworks,
                Title = a.Title,
                EndDate = a.EndDate,
                StartDate = a.StartDate,
                Artworks = a.ExhibitionArtworks.Select( a => new ArtworkDTO()
                {
                    InsuranceValue = a.InsuranceValue,
                    Title = a.Artwork.Title,
                    YearCreated = a.Artwork.YearCreated,
                    Artist = new ArtistDTO()
                    {
                        FirstName = a.Artwork.Artist.FirstName,
                        LastName = a.Artwork.Artist.LastName,
                        BirthDate = a.Artwork.Artist.BirthDate
                    }
                }).ToList()
            }).ToList()
        };
        return galleryDto;
    }

    public async Task<ExhibitStatus> AddExhibition(NewExhibitionDTO exhibition)
    {

        Gallery? gallery = context.Galleries.FirstOrDefault(a => a.Name.Equals(exhibition.Gallery));
        if (gallery == null)
        {
            return ExhibitStatus.GALLERYNOTFOUND;
        }

        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            int exhibitionId = context.Exhibitions.Select(a => a.ExhibitionId).Max() + 1;
            Exhibition exh = new Exhibition()
            {
                GalleryId = gallery.GalleryId,
                StartDate = exhibition.StartDate,
                EndDate = exhibition.EndDate,
                Title = exhibition.Title,
                ExhibitionId = exhibitionId,
                NumberOfArtworks = exhibition.Artworks.Count
            };

            foreach (var artwork in exhibition.Artworks)
            {
                if (context.Artworks.Select( a => a.ArtworkId).Count() != 1)
                {
                    transaction.Rollback();
                    return ExhibitStatus.ARTWORKNOTFOUND;
                }

                context.ExhibitionArtworks.Add(new ExhibitionArtwork()
                {
                    ArtworkId = artwork.ArtworkId,
                    InsuranceValue = artwork.InsuranceValue,
                    ExhibitionId = exhibitionId
                });
            }

            await context.SaveChangesAsync();
            transaction.Commit();
            return ExhibitStatus.SUCCESS;
        }
    }
}