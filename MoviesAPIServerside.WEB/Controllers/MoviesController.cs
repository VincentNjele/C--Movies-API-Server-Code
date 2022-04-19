using Microsoft.AspNetCore.Mvc;
using ServersideServices.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serverside.WEB.Controllers
{
    public class MoviesController : Controller
    {
        readonly string key = "9a641d7ad668061cbadbd503b17ed7cf";
        private readonly IService _generalRepository;

        public MoviesController(IService generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("api/[controller]")]


        public IActionResult GetPopular()
        {

            var getResponse = _generalRepository.GetPopular();

            if (getResponse == null)
            {
                return NotFound();
            }


            return Ok(getResponse);
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetSingle(int id)
        {

            var getResponse = _generalRepository.GetSingleMovie(id);

            if (getResponse == null)
            {
                return NotFound();
            }

            return Ok(getResponse);
        }
    }
}
