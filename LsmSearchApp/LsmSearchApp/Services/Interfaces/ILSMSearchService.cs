using LsmSearchApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LsmSearchApp.Services.Interfaces
{
    public interface ILSMSearchService
    {  
        // this method is used by the LSMSearch API to search for relevant results
        List<EntityDto> SearchText(string Text);
    }
}
