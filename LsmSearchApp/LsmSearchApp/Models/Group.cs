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


        // Calculate the weight of Group record based on searchText, also calculate WeightT for child entities
        public void CalculateEntityWeight(string searchText)
        {
            int NameWeight = CalculateAttributeWeight(searchText, Name, (int)GroupWeight.NameWeight);
            int DescriptionWeight = CalculateAttributeWeight(searchText, Description, (int)GroupWeight.DescriptionWeight);
            // Total Group weight
            Weight = NameWeight + DescriptionWeight;

            // if total weight is not 0 
            //calculate the WeightT 
            if (Weight > 0)
            {
                // calculate WeightT value of respective Attribute( for which match was found)
                WeightT += NameWeight > 0 ? (int)GroupWeight.NameWeightT : 0; 
                WeightT += DescriptionWeight > 0 ? (int)GroupWeight.DescriptionWeightT : 0;
            }
        }

    }
}
