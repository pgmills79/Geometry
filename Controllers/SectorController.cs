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
            //first see if bottom triangle
           


            List<string> _firstVertex = _services.GetAllVertexes(input)["V1"];
            List<string> _secondVertex = _services.GetAllVertexes(input)["V2"];
            List<string> _thirdVertex = _services.GetAllVertexes(input)["V3"];
            int _column = 0;
            string _row = string.Empty;

            Sector _sector = new Sector();

            //is it bottom triangle
            bool _isBottomTriangle = Convert.ToInt16(_secondVertex[1]) > Convert.ToInt16(_firstVertex[1]);

            if (_isBottomTriangle)  //so we would know that the number is odd
            {
                

                    _column = _sector.XCoords
                    .Where(
                            a => a.Value.Equals(Convert.ToInt16(_firstVertex[0]))
                            &
                            a.Key % 2 != 0
                          )
                    .Select(a => a.Key)
                    .FirstOrDefault<int>();

                    _row = _sector.YCoords
                    .Where(
                            a => a.Value.Equals(Convert.ToInt16(_firstVertex[1]))
                            &
                            Convert.ToInt16(a.Key.Substring(1, 1)) % 2 != 0
                          )
                    .Select(a => a.Key.Substring(0, 1))
                    .FirstOrDefault<string>();

            }
            else
            {
                 _column = _sector.XCoords
                  .Where(
                          a => a.Value.Equals(Convert.ToInt16(_firstVertex[0]))
                          &
                          a.Key % 2 == 0
                        )
                  .Select(a => a.Key)
                  .FirstOrDefault<int>();

                _row = _sector.YCoords
                   .Where(
                           a => a.Value.Equals(Convert.ToInt16(_firstVertex[1]))
                           &
                           Convert.ToInt16(a.Key.Substring(1, 1)) % 2 == 0
                         )
                   .Select(a => a.Key.Substring(0, 1))
                   .FirstOrDefault<string>();

            }


            _sector.Results = "You chose: " + _row + _column.ToString();

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
