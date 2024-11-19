using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class AlbumArtist
    {
        public int AlbumId { get; set; }    
        public int ArtistId { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }  
    }
}
