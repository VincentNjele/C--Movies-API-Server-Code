using Microsoft.AspNetCore.Mvc;
using ServersideServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serverside.WEB.Controllers
{
    public class SearchController : Controller
    {
        private readonly IService _generalRepository;

        public SearchController(IService generalRepository)
        {
            _generalRepository = generalRepository;
        }

        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult SearchForMovie(string searchName)
        {

            var getResponse = _generalRepository.SearchForMovie(searchName);

            if (getResponse == null)
            {
                return NotFound();
            }

            return Ok(getResponse);
        }
    }
}

