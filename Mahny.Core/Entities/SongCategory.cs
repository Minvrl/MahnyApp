using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class SongCategory
    {
        public int SongId { get; set; } 
        public int CategoryId { get; set; }
        public Song Song { get; set; }
        public Category Category { get; set; }  
    }
}
