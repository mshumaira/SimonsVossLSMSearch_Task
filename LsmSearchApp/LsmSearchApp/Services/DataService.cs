using LsmSearchApp.Models;
using LsmSearchApp.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Services
{
    public class DataService : IDataService
    {
        // path of json file
        private readonly string _jsonDataFilePath = @".\JsonData\sv_lsm_data.json";

        // Json file is parsed in to follow object
        // where each list is separated
        private EntitiesData _entitiesData;

        // All data records are added in a dictionary to speed up the search process 
        //Entity because we will be adding all the type of entity records in it(base model is used)
        private Dictionary<string, Entity> _dataRecordsDict;

        public DataService()
        {
            //Initialize the dictionary record
            _dataRecordsDict = new Dictionary<string, Entity>();
            // Read Json data from the file
            ReadJsonData();
            // add all the records read from json file in a dictionary
            AddRecordsInDictionary();
        }

        private void ReadJsonData()
        {
            var settings = new JsonSerializerSettings()
            {
                Culture = new System.Globalization.CultureInfo("de-DE")
            };
            // Read All Data and parse the content based on arrays define in EntitiesData
            _entitiesData = JsonConvert.DeserializeObject<EntitiesData>(File.ReadAllText(_jsonDataFilePath, System.Text.Encoding.UTF7), settings);
        }

        private void AddRecordsInDictionary()
        {
            AddBuildings();
            AddGroups();
            AddLocks();
            AddMediums();
        }

        private void AddBuildings()
        {
            // Add all the buildings
            foreach (var building in _entitiesData.buildings)
            {
                _dataRecordsDict.Add(building.Id, building);
            }
        }

        private void AddGroups()
        {
            // Add all the groups 
            foreach (var group in _entitiesData.groups)
            {
                _dataRecordsDict.Add(group.Id, group);
            }
        }

        private void AddLocks()
        {
            // Add all the locks
            foreach (var lockobj in _entitiesData.locks)
            {
                // Adding building reference in lock
                // Adding lock reference in Building
                if (!string.IsNullOrEmpty(lockobj.BuildingId))
                {
                    ((Building)_dataRecordsDict[lockobj.BuildingId]).Locks.Add(lockobj.Id);
                    // Add the information of parent building as well.
                    lockobj.Building = ((Building)_dataRecordsDict[lockobj.BuildingId]);
                    //((Building)_dataRecordsDict[lockobj.BuildingId]).Locks.Add(lockobj);
                }

                _dataRecordsDict.Add(lockobj.Id, lockobj);
            }
        }

        private void AddMediums()
        {
            // Add all the mediums
            foreach (var medium in _entitiesData.media)
            {
                // Adding Group reference in Medium
                // Adding Medium reference in Group
                if (!string.IsNullOrEmpty(medium.GroupId))
                {
                    ((Group)_dataRecordsDict[medium.GroupId]).Mediums.Add(medium.Id);
                    // Add the information of parent Group as well.
                    medium.Group = ((Group)_dataRecordsDict[medium.GroupId]);
                    //((Group)_dataRecordsDict[medium.GroupId]).Mediums.Add(medium);
                }

                _dataRecordsDict.Add(medium.Id, medium);
            }
        }


        // expose the Dictionary data to other components in backend
        public Dictionary<string, Entity> GetDataDictionary()
        {
            return _dataRecordsDict;
        }

        // expose the Entities data to other components in backend
        public EntitiesData GetEntitiesData()
        {
            return _entitiesData;
        }
    }
}
