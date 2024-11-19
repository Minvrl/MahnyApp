using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class Album:AuditEntity
    {
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; }
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public bool IsSingle { get; set; }
        public string Image {  get; set; }
        public List<int>? SongIds { get; set; }
        public List<Song> Songs { get; set; }   = new List<Song>();
        public List<AlbumArtist> AlbumArtists { get; set; } = new List<AlbumArtist> ();

    }
}
