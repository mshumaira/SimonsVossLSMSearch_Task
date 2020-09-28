using LsmSearchApp.Models;
using LsmSearchApp.Models.Dtos;
using LsmSearchApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Services
{

    public class LSMSearchService : ILSMSearchService
    {
        //Data service to extract the data
        private IDataService _dataService;

        //Search results are stored in the following list
        private List<EntityDto> _searchResults;

        //SearchText Entered by user
        private string _searchText;

        //Dictionary which store all the records
        private Dictionary<string, Entity> _dataRecordsDict;

        public LSMSearchService(IDataService dataService)
        {
            // Data service is initialized
            _dataService = dataService;
        }
        // Search Function which return list of relevant entities based on the searchText
        public List<EntityDto> SearchText(string searchText)
        {
            try
            {
                // for every search request it is initialized again
                _searchResults = new List<EntityDto>();
                _searchText = searchText;
                _dataRecordsDict = _dataService.GetDataDictionary();

                // extract the relevant entities and add them in _searchResults array
                GetRelevantBuildings();
                GetRelevantLocks();
                // Extract relevant Groups
                // Extract relevant Mediums

                // order the searchResults based on weight
                if (_searchResults.Count > 0)
                {  
                    // order the search result based on the weight
                    // record with highest weight value will come first
                    return _searchResults.OrderByDescending(entity => entity.Weight)
                        .ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        // Extract relevant buildings
        private void GetRelevantBuildings()
        {
            // check all the buildings
            foreach (var buildingObj in _dataService.GetEntitiesData().buildings)
            {
                // calculate the weight of a building record
                buildingObj.CalculateEntityWeight(_searchText);

                // Adding WeightT to all child Entities of building
                if (buildingObj.WeightT > 0)
                {
                    // Iterate over all the locks and add the weightT
                    foreach (var lockobj in buildingObj.Locks)
                    {
                        if (_dataRecordsDict.ContainsKey(lockobj))
                        {   // update the weight of lock
                            _dataRecordsDict[lockobj].Weight = buildingObj.WeightT;
                        }
                    }
                    // for next search make the calculated weightT zero
                    buildingObj.WeightT = 0;
                }

                // if weight is not 0 then add this building in the result search array
                if (buildingObj.Weight > 0)
                {
                    var buildingTemp = new BuildingDto();
                    buildingTemp.Put(buildingObj);
                    _searchResults.Add(buildingTemp);

                    // for next search make the calculated weight zero
                    buildingObj.Weight = 0;
                }
            }
        }

        // Extract relevant Locks
        private void GetRelevantLocks()
        {
            // check all the Locks
            foreach (var lockObj in _dataService.GetEntitiesData().locks)
            {
                // calculate the weight of a Lock record
                lockObj.CalculateEntityWeight(_searchText);

                // if weight is not 0 then add it in the result array
                if (lockObj.Weight > 0)
                {
                    var lockTemp = new LockDto();
                    lockTemp.Put(lockObj);
                    _searchResults.Add(lockTemp);
                    // for next search make the calculated weight zero
                    lockObj.Weight = 0;
                }
            }
        }

        // Extract relevant Groups

        // Extract relevant Mediums

    }
}
