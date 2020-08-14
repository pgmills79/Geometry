using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CsvHelper;
using Geometry.Models;
using Geometry.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Geometry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeometryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IGeometryServices _services;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GeometryController> _logger;

        public GeometryController(IConfiguration iconfiguration, IGeometryServices services)
        {

            _configuration = iconfiguration;
            _services = services;




        }

        [HttpGet]
        public IEnumerable<Coordinates> Get()
        {

            string _userInput = "E7";


            //First check if input is correct

            //next get the x cordinates...
            int _xCord = _services.GetXCordinates(_userInput);
            int _yCord = _services.GetYCordinates(_userInput);

            return new Coordinates { xCord = _xCord, yCord}
        }
    }
}
