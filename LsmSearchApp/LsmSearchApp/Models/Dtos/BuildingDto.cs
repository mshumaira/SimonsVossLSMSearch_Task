using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models.Dtos
{
    // this object is used to send data to clientApplication
    public class BuildingDto : EntityDto
    {
        public string ShortCut { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //Method to update DTO attributes
        public void Put(Building buildingObj)
        {
            //Assign passed Data to the DTO fields  
            Id = buildingObj.Id;
            ShortCut = buildingObj.ShortCut;
            Name = buildingObj.Name;
            Description = buildingObj.Description;
            EntityType = TypeOfEntity.Building.ToString();
            Weight = buildingObj.Weight;

        }
    }
}
