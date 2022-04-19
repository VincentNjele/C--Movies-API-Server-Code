using ServersideServices.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServersideServices.DAL.Interfaces
{
    public interface IService
    {
        Result GetPopular();
        Result SearchForMovie(string movieName);
        SearchSingle GetSingleMovie(int id);
      
    }
}
