using ServersideServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersideServices.DAL.Helpers
{
   public class GetProperties
    {
        public MovieProperties GetAllProperties()
        {

            MovieProperties properties = new MovieProperties();

            properties.adult = false;
            properties.backdrop_path = "../data/";
            //properties.belongs_to_collection = null;
            properties.budget = 30000;
            properties.genres = new List<genres>()
            {
                new genres
                {
                     id = 1,
                     name= "Mech"
                }
            };
            properties.id = 5;
            //properties.imdb_id = "jehtkli";
            properties.original_language = "English";
            properties.original_title = "Homecoming";

            return properties;
        }

    }
}
