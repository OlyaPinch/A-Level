using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_6.DbModels
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime ReleasedDate { get; set; }
        public virtual Genre Genre { get; set; }
        public int? GenreId { get; set; }
        public virtual List<ArtistSong> ArtistSong { get; set; } = new List<ArtistSong>();
    }
}
