using Microsoft.EntityFrameworkCore;
using Module_4_6.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module_4_6.Configurations
{
    internal class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>

    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("Artist_Song")
                .HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasColumnName("ArtistSongId");

            builder.HasData(new ArtistSong
                {
                    Id = 1,
                    ArtistId = 1,
                    SongId = 1
                },
                new ArtistSong
                {
                    Id = 2,
                    ArtistId = 2,
                    SongId = 1
                },
                new ArtistSong
                {
                    Id = 3,
                    ArtistId = 4,
                    SongId = 2
                },
                new ArtistSong
                {
                    Id = 4,
                    ArtistId = 5,
                    SongId = 4
                },
                new ArtistSong
                {
                    Id = 5,
                    ArtistId = 4,
                    SongId = 6
                },
                new ArtistSong
                {
                    Id = 6,
                    ArtistId = 6,
                    SongId = 5
                }
            );
        }
    }
}