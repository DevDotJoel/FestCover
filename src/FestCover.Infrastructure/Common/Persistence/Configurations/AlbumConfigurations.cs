using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FestCover.Domain.Albums;
using FestCover.Domain.Albums.ValueObjects;
using FestCover.Domain.Common;
using FestCover.Domain.AlbumContents.ValueObjects;

namespace FestCover.Infrastructure.Common.Persistence.Configurations
{
    public class AlbumConfigurations : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            ConfigureAlbumTable(builder);
            ConfigureAlbumContentIdsTable(builder);
        }
        private static void ConfigureAlbumTable(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(v => v.Value, src => AlbumId.Create(src)).ValueGeneratedNever();
            builder.Property(x => x.UserId).HasConversion(v => v.Value, src => UserId.Create(src)).ValueGeneratedNever();
        }
        private void ConfigureAlbumContentIdsTable(EntityTypeBuilder<Album> builder)
        {
            builder.OwnsMany(m => m.AlbumContentIds, dib =>
            {
                dib.ToTable("AlbumContentIds");

                dib.WithOwner().HasForeignKey("AlbumId");

                dib.HasKey("Id");

                dib.Property(d => d.Value)
                    .HasColumnName("AlbumContentId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Album.AlbumContentIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}
