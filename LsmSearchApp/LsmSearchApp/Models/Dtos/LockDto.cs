using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models.Dtos
{
    // this object is used to send data to clientApplication
    public class LockDto : EntityDto
    {
        public string BuildingId { get; set; }
        public string BuildingName { get; set; }
        public BuildingDto Building { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Floor { get; set; }
        public string RoomNumber { get; set; }
        public string Description { get; set; }

        //Method to update DTO attributes
        public void Put(Lock lockObj)
        {
            //Assign passed Data to the DTO fields  
            Id = lockObj.Id;
            BuildingId = lockObj.BuildingId;
            Type = lockObj.Type;
            Name = lockObj.Name;
            SerialNumber = lockObj.SerialNumber;
            Floor = lockObj.Floor;
            RoomNumber = lockObj.RoomNumber;
            Description = lockObj.Description;
            Weight = lockObj.Weight;
            EntityType = TypeOfEntity.Lock.ToString();

            if (lockObj.Building != null)
            {
                Building = new BuildingDto();
                Building.Put(lockObj.Building);
            }

        }
    }
}
