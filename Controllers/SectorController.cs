using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            //instantiate new Sector class which "houses" our grid relationships
            Sector _sector = new Sector();

            //Went ahead and put all the logic for the setor gathering in this service...
            _sector.Results = _services.GetTriangleSector(input);

            return _sector;
        }

        // POST api/<SectorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SectorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
