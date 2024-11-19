using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class SongArtist
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public Song Song { get; set; }
        public Artist Artist { get; set; }
    }
}
