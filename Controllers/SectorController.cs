using System.Collections.Generic;
using System.Net;
using Geometry.Models;
using Geometry.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Geometry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IGeometryServices _services;

        public SectorController(IConfiguration iconfiguration, IGeometryServices services)
        {
            _configuration = iconfiguration;
            _services = services;
        }

        // GET: api/<SectorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return null ;
        }

        // GET api/<SectorController>/5
        [HttpGet("{input}")]
        public Sector Get(string input)
        {

            string _userInput = input;

            //Make sure correct input using an extension method I created in Extensions.cs
            bool isValid = _userInput.isValidVertexInput();

            if (!isValid)
            {
                Sector _badInput = new Sector();
                _badInput.Results = HttpStatusCode.BadRequest.ToString();
                return _badInput;

            }

            //instantiate new Sector class which "houses" our grid relationships
            Sector _sector = new Sector();

            //Went ahead and put all the logic for the setor gathering in this service...
            _sector.Results = _services.GetTriangleSector(_userInput);

            //return the sector class with only the results property visible
            return _sector;
        }

       
    }
}
