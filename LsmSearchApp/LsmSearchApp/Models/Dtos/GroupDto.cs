using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Models.Dtos
{
    // this object is used to send data to clientApplication
    public class GroupDto : EntityDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Method to update DTO attributes
        public void Put(Group groupObj)
        {
            Id = groupObj.Id;
            Name = groupObj.Name;
            Description = groupObj.Description;
            EntityType = TypeOfEntity.Group.ToString();
            Weight = groupObj.Weight;
        }
    }
}
