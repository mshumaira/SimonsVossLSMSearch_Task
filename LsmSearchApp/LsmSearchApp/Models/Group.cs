using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models
{
    // Weights of Group Attributes
    public enum GroupWeight
    {
        // Weight of Own Attributes
        NameWeight = 9,
        DescriptionWeight = 5,
        // Weight of Transitive Attributes
        NameWeightT = 8,
        DescriptionWeightT = 0,
    }


    // this class represents the Group entity of the Data
    public class Group : Entity
    {
        // Attributes of Group
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Mediums { get; set; }
        public int WeightT { get; set; }
        public Group()
        {
            Mediums = new List<string>();
            WeightT = 0;
        }

        // Calculate the weight of Group record based on searchText
        public void CalculateEntityWeight(string searchText)
        {
        }

     }
}
