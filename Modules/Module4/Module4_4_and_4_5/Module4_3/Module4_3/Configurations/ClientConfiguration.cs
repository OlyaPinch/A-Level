using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_3.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_3.Configurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .ToTable("Client")
                .HasKey(e => e.Id);
            builder
                .Property(e => e.Id)
                .HasColumnName("ClientId")
                .ValueGeneratedNever();



            builder.HasData(new Client()
            {
                Id=1,
                Name = "Client1",
                Description = "Good client",
                Mail="client1@gmail.com",
                Phone = "000-000-00-01"

            },
            new Client()
            {
                Id = 2,
                Name = "Client2",
                Description = "Good client",
                Mail = "client2@gmail.com",
                Phone = "000-000-00-02"

            },
            new Client()
            {
                Id = 3,
                Name = "Client3",
                Description = "Good client",
                Mail = "client3@gmail.com",
                Phone = "000-000-00-03"

            },
            new Client()
            {
                Id = 4,
                Name = "Client4",
                Description = "Good client",
                Mail = "client4@gmail.com",
                Phone = "000-000-00-04"

            },
            new Client()
            {
                Id = 5,
                Name = "Client5",
                Description = "Good client",
                Mail = "client5@gmail.com",
                Phone = "000-000-00-05"

            });

        }
    }
}