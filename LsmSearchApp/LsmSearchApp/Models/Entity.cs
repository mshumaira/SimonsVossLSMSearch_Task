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


        //Calculate the weight of one Field Based on SearchText
        //Look for full or partial match in text
        public int CalculateAttributeWeight(string searchText, string attributeData, int attributeWeight)
        {
            // If attributeData is not null other indexOf function can give ArgumentNullException 
            // Returns the index of place where the first character of the SearchText match with attributeData 
            // Compare method returns -1 if no match
            // Compare the string by ignoring it's case
            if (!string.IsNullOrEmpty(attributeData) && !string.IsNullOrEmpty(searchText) && (attributeData.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0))
            {  //|| attributeData.IndexOf(searchText, StringComparison.InvariantCultureIgnoreCase)>=0

                // Full Match
                if (attributeData.Length == searchText.Length && (attributeData.Equals(searchText, StringComparison.OrdinalIgnoreCase)))
                {
                    //attributeData.Equals(searchText, StringComparison.InvariantCultureIgnoreCase)

                    //Multipling with 10- for 10x more relevant 
                    //in case of full match
                    return (attributeWeight * 10);
                }
                else //Partial Match
                {
                    return attributeWeight;
                }
            }
            // if attribute Data or search text is null or empty return 0;
            return 0;
        }
    }

}
