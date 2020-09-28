using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LsmSearchApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LsmSearchApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LSMSearchController : ControllerBase
    {
        // services variables
        private ILogger<LSMSearchController> _logger;
        private ILSMSearchService _lsmSearchService;

        // services will be initialized here 
        public LSMSearchController(ILogger<LSMSearchController> logger, ILSMSearchService lsmSearchService)
        {
            _logger = logger;
            _lsmSearchService = lsmSearchService;
        }

        /// <summary>
        /// Search the Text
        /// </summary>
        /// <param name="searchText">Search Text</param>
        /// <returns>Returns JSON object List of all the relevant entities(dto)</returns>
        [HttpGet("[action]")]
        public IActionResult LSMSearchText(string searchText)
        {
            try
            {   // check if search text is not null
                if (!string.IsNullOrEmpty(searchText))
                {
                    // compute the search results here
                    var searchResults = _lsmSearchService.SearchText(searchText);
                    if (searchResults != null)
                    {
                        string JsonResult = JsonConvert.SerializeObject(searchResults);
                        return Ok(JsonResult);
                    }
                }
                // Return Notfound incase of Search Text is null or empty
                return NotFound("Search Text not found");
            }
            catch (Exception ex)
            {
                //log error 
                _logger.LogError(ex, "Exception During searching");
                // Write excpetion in console
                Console.WriteLine("Exception During searching " + ex.Message);
                // Sending back badRequest error
                return BadRequest("Exception During searching " + ex.Message);
            }

        }

    }
}