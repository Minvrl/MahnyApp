using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class Song:AuditEntity
    {
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int Plays { get; set; }
        public int Likes { get; set; }
        public DateTime Release {  get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<SongCategory> SongCategories { get; set; } =  new List<SongCategory>();
        public List<SongArtist> SongArtists { get; set; } = new List<SongArtist>();

    }
}
