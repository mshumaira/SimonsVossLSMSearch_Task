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
                // Extract relevant buildings
                // Extract relevant Locks
                // Extract relevant Groups
                // Extract relevant Mediums

                // order the searchResults based on weight
                if (_searchResults.Count > 0)
                {

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

        // Extract relevant Locks

        // Extract relevant Groups

        // Extract relevant Mediums

    }
}
