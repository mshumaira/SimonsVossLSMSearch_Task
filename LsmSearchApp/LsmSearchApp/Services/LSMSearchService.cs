﻿using LsmSearchApp.Models;
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
                GetRelevantGroups();
                GetRelevantMediums();

                // if any relevant results are found then order them
                if (_searchResults.Count > 0)
                {
                    // order the search result based on the weight
                    return OrderSearchResults();
                }

                // if no relevant results are found return null
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
        private void GetRelevantGroups()
        {
            // check all the Groups
            foreach (var groupObj in _dataService.GetEntitiesData().groups)
            {
                // calculate the weight of a group record
                groupObj.CalculateEntityWeight(_searchText);

                // Assign WeightT to all the child entities of group
                if (groupObj.WeightT > 0)
                {
                    // Iterate over all the medias and add the weightT
                    foreach (var medium in groupObj.Mediums)
                    {
                        if (_dataRecordsDict.ContainsKey(medium))
                        {   // update the weight of mediums
                            _dataRecordsDict[medium].Weight = groupObj.WeightT;
                        }
                    }
                    // for next search make the calculated weightT zero
                    groupObj.WeightT = 0;
                }

                // if weight is not 0 then add it in the result array
                if (groupObj.Weight > 0)
                {
                    var groupTemp = new GroupDto();
                    groupTemp.Put(groupObj);
                    _searchResults.Add(groupTemp);
                    // for next search make the calculated weight zero
                    groupObj.Weight = 0;
                }

            }
        }

        // Extract relevant Mediums
        private void GetRelevantMediums()
        {
            // check all the Mediums/Media
            foreach (var mediumObj in _dataService.GetEntitiesData().media)
            {
                // calculate the weight of medium record
                mediumObj.CalculateEntityWeight(_searchText);

                // if weight is not 0 then add it in the result array
                if (mediumObj.Weight > 0)
                {
                    var mediumTemp = new MediumDto();
                    mediumTemp.Put(mediumObj);
                    _searchResults.Add(mediumTemp);
                    // for next search make the calculated weight zero
                    mediumObj.Weight = 0;
                }
            }
        }

        // order the search results based on weight
        private List<EntityDto> OrderSearchResults()
        {
            // record with highest weight value will come first
            return _searchResults.OrderByDescending(entity => entity.Weight)
                .ToList();
        }
    }
}
