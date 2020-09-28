using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models
{
    // this represents the type of entities in Data
    public enum TypeOfEntity
    {
        Building = 1,
        Lock = 2,
        Group = 3,
        Medium = 4,
    }
    // This class represents the base model of the entities
    public class Entity
    {
        // Atributes of base model, which are common in every entity
        public string Id { get; set; }
        public int Weight { get; set; }
        public Entity()
        {
            Weight = 0;
        }

        public static int CalculateAttributeWeight(string searchText, string attributeData, int attributeWeight)
        {
            //compare
            //check for fullmatch
            //check for partial match
            // incase if null or empty attribute Data return 0;
            return 0;
        }
    }

}
