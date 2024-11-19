using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahny.Core.Entities
{
    public class Category:AuditEntity
    {
        [MinLength(2)]
        [MaxLength(45)]
        public string Name { get; set; }
    }
}
