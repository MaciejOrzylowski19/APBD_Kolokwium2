using Kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_2.DB;

public class DatabaseContext : DbContext
{
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set;}
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>().HasData(new List<Artist>()
        {
            new Artist() {ArtistId = 1, FirstName = "Franek", LastName = "Zak", BirthDate = new DateTime(1999, 12, 1)},
            new Artist() {ArtistId = 2, FirstName = "Lui", LastName = "Wolo", BirthDate = new DateTime(1899, 11, 8)},
            new Artist() {ArtistId = 3, FirstName = "Sashka", LastName = "Bicepsik", BirthDate = new DateTime(1939, 8, 9)},
        });

        modelBuilder.Entity<Artwork>().HasData(new List<Artwork>()
        {
            new Artwork() { ArtworkId = 1, ArtistId = 1, Title = "Jozin Zbazin", YearCreated = 2012},
            new Artwork() { ArtworkId = 2, ArtistId = 1, Title = "Jo Zbazin", YearCreated = 2020},
            new Artwork() { ArtworkId = 3, ArtistId = 2, Title = "in", YearCreated = 1912},
            new Artwork() { ArtworkId = 4, ArtistId = 3, Title = "Zuch", YearCreated = 1979},
        });
        modelBuilder.Entity<Gallery>().HasData(new List<Gallery>()
        {
            new Gallery() { GalleryId = 1, EstablishedDate = new DateTime(1324, 12, 3), Name = "Bydgoszcz" },
            new Gallery()
            {
                GalleryId = 2, EstablishedDate = new DateTime(1132, 3, 2), Name = "Siedlckie muzeum prawie diecezjalne"
            }
        });

        modelBuilder.Entity<Exhibition>().HasData(new List<Exhibition>()
        {
            new Exhibition()
            {
                GalleryId = 1,
                ExhibitionId = 1,
                Title = "Choroszcza",
                StartDate = DateTime.Today,
                EndDate = null,
                NumberOfArtworks = 3
            },
            new Exhibition()
            {
                GalleryId = 2,
                ExhibitionId = 2,
                Title = "Sock",
                StartDate = new DateTime(2023, 12, 3),
                EndDate = new DateTime(2024, 1, 3),
                NumberOfArtworks = 10
            }
        });

        modelBuilder.Entity<ExhibitionArtwork>().HasData(new List<ExhibitionArtwork>()
        {
            new ExhibitionArtwork() { ExhibitionId = 1, ArtworkId = 1, InsuranceValue = new decimal(12) },
            new ExhibitionArtwork() { ExhibitionId = 1, ArtworkId = 2, InsuranceValue = new decimal(24) },
            new ExhibitionArtwork() { ExhibitionId = 2, ArtworkId = 3, InsuranceValue = new decimal(55) },
            new ExhibitionArtwork() { ExhibitionId = 2, ArtworkId = 1, InsuranceValue = new decimal(123) }
        });
    }
    
}