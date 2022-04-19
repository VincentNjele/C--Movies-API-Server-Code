using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersideServices.DAL.Models
{
    public class Result
    {
        public int page { get; set; }
        public List<SearchResults> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
