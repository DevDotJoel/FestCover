using FestCover.Domain.Albums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestCover.Domain.AlbumContents;
using FestCover.Domain.AlbumContents.ValueObjects;
using FestCover.Domain.Albums.ValueObjects;

namespace FestCover.Infrastructure.Common.Persistence.Configurations
{
    public class AlbumContentConfigurations : IEntityTypeConfiguration<AlbumContent>
    {
        public void Configure(EntityTypeBuilder<AlbumContent> builder)
        {
            ConfigureAlbumTable(builder);
        }
        private static void ConfigureAlbumTable(EntityTypeBuilder<AlbumContent> builder)
        {
            builder.ToTable("AlbumContents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasConversion(v => v.Value, src => AlbumContentId.Create(src)).ValueGeneratedNever();
            builder.Property(x => x.AlbumId).HasConversion(v => v.Value, src => AlbumId.Create(src)).ValueGeneratedNever();
        }
    }
}
