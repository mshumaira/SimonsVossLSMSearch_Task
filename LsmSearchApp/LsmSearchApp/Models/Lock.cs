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
        }

     }
}
