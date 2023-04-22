using Microsoft.EntityFrameworkCore;
using Module_4_6.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module_4_6.Configurations
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>

    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre")
                .HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .HasColumnName("GenreId").IsRequired();
            builder.Property(i=>i.Title).IsRequired();
          

            builder.HasData(new Genre()
                {
                    Id = 1,
                    Title = "Country"
                },
                new Genre()
                {
                    Id = 2,
                    Title = "Rock"
                },
                new Genre()
                {
                    Id = 3,
                    Title = "Pop"
                },
                new Genre()
                {
                    Id = 4,
                    Title = "R&B"
                },
                new Genre()
                {
                    Id = 5,
                    Title = "Blues"
                });
        }
    }
}