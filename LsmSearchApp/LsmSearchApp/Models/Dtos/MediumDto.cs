using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models.Dtos
{

    // this object is used to send data to clientApplication
    public class MediumDto : EntityDto
    {
        public string GroupId { get; set; }
        public GroupDto Group { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        //Method to update DTO attributes
        public void Put(Medium mediumObj)
        {
            Id = mediumObj.Id;
            GroupId = mediumObj.GroupId;
            Type = mediumObj.Type;
            Owner = mediumObj.Owner;
            SerialNumber = mediumObj.SerialNumber;
            Description = mediumObj.Description;
            EntityType = TypeOfEntity.Medium.ToString();
            Weight = mediumObj.Weight;

            if (mediumObj.Group != null)
            {
                Group = new GroupDto();
                Group.Put(mediumObj.Group);
            }
        }
    }
}
