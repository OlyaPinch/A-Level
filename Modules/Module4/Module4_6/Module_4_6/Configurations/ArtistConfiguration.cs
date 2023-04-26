using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module_4_6.DbModels;

namespace Module_4_6.Configurations
{
    internal class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist")
                .HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasColumnName("ArtistId")
                .IsRequired();
            builder.Property(i => i.DateOfBirth)
                .IsRequired();
            builder.HasData(new Artist()
                {
                    Id = 1,
                    Name = "Elvis Presley",
                    DateOfBirth = DateTime.Parse("08-01-1935"),
                    DateOfDeath = DateTime.Parse("16-08-1977"),
                },
                new Artist()
                {
                    Id = 2,
                    Name = "Brenda Lee",
                    DateOfBirth = DateTime.Parse("11-12-1944")
                },
                new Artist()
                {
                    Id = 3,
                    Name = "Madonna",
                    DateOfBirth = DateTime.Parse("16-08-1958"),
                    InstagramUrl = $"https://www.instagram.com/madonna/"
                },
                new Artist()
                {
                    Id = 4,
                    Name = "Louis Armstrong",
                    DateOfBirth = DateTime.Parse("04-08-1901"),
                    DateOfDeath = DateTime.Parse("06-07-1971"),
                },
                new Artist()
                {
                    Id = 5,
                    Name = "Mariah Carey",
                    DateOfBirth = DateTime.Parse("04-08-1901"),
                },
                new Artist()
                {
                    Id = 6,
                    Name = "Ed Sheeran",
                    DateOfBirth = DateTime.Parse("17-02-1991"),
                    InstagramUrl = $"https://www.instagram.com/teddysphotos/"
                }
            );
        }
    }
}