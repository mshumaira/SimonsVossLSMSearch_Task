using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models
{
    // Weights of Lock Attributes
    public enum LockWeight
    {
        // Weight of Own Attributes
        TypeWeight = 3,
        NameWeight = 10,
        SerialNumberWeight = 8,
        FloorWeight = 6,
        RoomNumberWeight = 6,
        DescriptionWeight = 6,
    }


    // this class represents the Lock entity of the Data
    public class Lock : Entity
    {
        // Attributes of Group
        public string BuildingId { get; set; }
        public Building Building { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }

        public Lock()
        {
        }


        // Calculate the weight of Lock record based on searchText
        public void CalculateEntityWeight(string searchText)
        {
            // add new weight in it because previously WeightT could be added incase of Match with parent Building
            Weight += CalculateAttributeWeight(searchText, Type, (int)LockWeight.TypeWeight);
            Weight += CalculateAttributeWeight(searchText, Name, (int)LockWeight.NameWeight);
            Weight += CalculateAttributeWeight(searchText, SerialNumber, (int)LockWeight.SerialNumberWeight);
            Weight += CalculateAttributeWeight(searchText, Floor, (int)LockWeight.FloorWeight);
            Weight += CalculateAttributeWeight(searchText, RoomNumber, (int)LockWeight.RoomNumberWeight);
            Weight += CalculateAttributeWeight(searchText, Description, (int)LockWeight.DescriptionWeight);
        }

    }
}
