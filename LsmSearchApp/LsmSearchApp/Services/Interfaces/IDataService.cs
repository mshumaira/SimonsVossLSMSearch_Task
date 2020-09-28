using LsmSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Services.Interfaces
{
    public interface IDataService
    {
        // Get All the data in the form of List
        EntitiesData GetEntitiesData();
        // Get a Dictionary with all the records from all the entities, with ID as the Key of the data
        Dictionary<string, Entity> GetDataDictionary();
    }
}
