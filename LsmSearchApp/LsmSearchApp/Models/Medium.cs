using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models
{

    // Weights of Medium Attributes
    public enum MediumWeight
    {
        // Weight of Own Attributes
        TypeWeight = 3,
        OwnerWeight = 10,
        SerialNumberWeight = 8,
        DescriptionWeight = 6,
    }

    // this class represents the Medium entity of the Data
    public class Medium : Entity
    {
        // Attributes of Medium
        public string GroupId { get; set; }
        public Group Group { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public Medium()
        {
        }


        // Calculate the weight of medium record based on searchText
        public void CalculateEntityWeight(string searchText)
        {
        }
    }
}
