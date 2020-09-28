using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models.Dtos
{
    public class EntityDto
    {
        public string Id { get; set; }
        public string EntityType { get; set; }
        public int Weight { get; set; }
    }
}
