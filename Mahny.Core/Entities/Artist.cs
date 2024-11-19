using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class Artist:AuditEntity
    {
        [MinLength(10)]
        [MaxLength(60)]
        public string Fullname { get; set; }
        public int Followers { get; set; }
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }
        public string Image {  get; set; }
        public List<AlbumArtist> AlbumArtists { get; set; } = new List<AlbumArtist>();
        public List<SongArtist> SongArtists { get; set;} = new List<SongArtist>();
    }
}
