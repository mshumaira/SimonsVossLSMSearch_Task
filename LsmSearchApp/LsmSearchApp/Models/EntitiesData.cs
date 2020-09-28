using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models
{
    public class EntitiesData
    { // List of entities which are present inside the JSON file- same names for the list are used
        public List<Building> buildings { get; set; }
        public List<Lock> locks { get; set; }
        public List<Group> groups { get; set; }
        public List<Medium> media { get; set; }
    }
}
