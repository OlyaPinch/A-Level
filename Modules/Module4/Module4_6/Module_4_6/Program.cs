using System.Collections.Immutable;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Module_4_6.DbModels;


namespace Module_4_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();
            var connString = configuration.GetConnectionString("SQLConn");
            ApplicationContextFactory.ConnectionString = connString;

            using (var context =
                   new ApplicationContextFactory().CreateDbContext(Array.Empty<string>()))

            {
                
               var songs = context.Songs
                   .Where(i => i.Genre != null && i.ArtistSong.Any(artist => artist.Artist.DateOfDeath == null))
                   .ToList().Select(i => new
                   {
                       Song = i.Title+i.Genre.Title, Artist = string.Join(",", i.ArtistSong.Select(i => i.Artist.Name)),
                   });
             

               var songsGroupByGenre = context.Songs.GroupBy(s => s.Genre.Title)
                   .Select(g => new { Genre = g.Key, NumSongs = g.Count() })
                   .ToList();

              
                var birthdayYoungestArtist = context.Artists.Max(i => i.DateOfBirth);   
               var songsBeforeYoungest = context.Songs
                   .Where(s => s.ReleasedDate<birthdayYoungestArtist )
                   .ToList();
               
            }
        }
    }
}