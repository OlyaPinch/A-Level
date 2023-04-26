using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_6.DbModels;

namespace Module_4_6.Configurations
{
    internal class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song")
                .HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasColumnName("SongId").IsRequired();
            builder.Property(i => i.Title).IsRequired();
            builder.Property(i => i.Duration).IsRequired();
            builder.Property(i => i.ReleasedDate).IsRequired();


            builder.HasData(new Song()
                {
                    Id = 1,
                    Title = "Always on My Mind",
                    ReleasedDate = DateTime.Parse("01-01-1972"),
                    Duration = 210,
                    GenreId = 1,
                }, new Song()
                {
                    Id = 2,
                    Title = "What a Wonderful World",
                    ReleasedDate = DateTime.Parse("16-08-1967"),
                    Duration = 81,
                    GenreId = 3,
                },
                new Song()
                {
                    Id = 3,
                    Title = "Ray of Light",
                    ReleasedDate = DateTime.Parse("16-08-1967"),
                    Duration = 81,
                    GenreId = 3,
                }, new Song()
                {
                    Id = 4,
                    Title = "We Belong Together",
                    ReleasedDate = DateTime.Parse("15-05-2005"),
                    Duration = 202,
                    GenreId = 4,
                }, new Song()
                {
                    Id = 5,
                    Title = "2step",
                    ReleasedDate = DateTime.Parse("22-04-2022"),
                    Duration = 163,
                    GenreId = 2,
                }, new Song()
                {
                    Id = 6,
                    Title = "Basin Street Blues",
                    ReleasedDate = DateTime.Parse("01-01-1935"),
                    Duration = 186,
                    GenreId = 5,
                }, new Song()
                {
                    Id = 7,
                    Title = "Song without genre",
                    ReleasedDate = DateTime.Parse("01-01-2022"),
                    Duration = 150,
                   
                }
            );
        }
    }
}