using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Service.Dtos.SliderDtos.Admin
{
    public class SliderListItemGetDto
    {
        public int Id { get; set; }
        public string PrimaryText { get; set; }
        public int Order { get; set; }
        public string Image { get; set; }
    }
}
