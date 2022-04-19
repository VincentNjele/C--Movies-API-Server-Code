using ServersideServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersideServices.DAL.Helpers
{
    public class GetSingleSampleData
    { 
        public SearchSingle SearchSingle()
        {
         SearchSingle searchSingle = new SearchSingle

                {
                    homepage = "../..//...",
                    overview = "Just testing",
                    poster_path = "//...//",
                    release_date = "2022-02-20",
                    title = "Matrix",
                };

            return searchSingle;
        }
       
    }
}
