using ServersideServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersideServices.DAL.Helpers
{
   public class SearchForMovieHelper
    {
        public Result GetSearchResults()
        {
            Result result = new Result();

            result.page = 1;
            result.results = new List<SearchResults>()
            {
                new()
                {
                     adult = false,
                     backdrop_path= "../value/correct",
                     original_language = "English",
                     original_title = "Value",
                     release_date = "2022-03-10",
                     vote_count = 10,
                     video = true,
                     popularity = 40000,
                },
               new() {
                     adult = false,
                     backdrop_path= "../value/correct",
                     original_language = "English",
                     original_title = "Value",
                     release_date = "2022-03-10",
                     vote_count = 10,
                     video = true,
                     popularity = 40000,
                },

               new() {
                     adult = false,
                     backdrop_path= "../value/correct",
                     original_language = "English",
                     original_title = "Value",
                     release_date = "2022-03-10",
                     vote_count = 10,
                     video = true,
                     popularity = 40000,
                },
            };
            result.total_pages = 3;
            result.total_results = 58;

            return result;

        }
    }
}
