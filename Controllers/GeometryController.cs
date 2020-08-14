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

    

        public GeometryController(IConfiguration iconfiguration, IGeometryServices services)
        {

            _configuration = iconfiguration;
            _services = services;

        }

        [HttpGet]
        public Coordinates Get()
        {

            string _userInput = "A10";


            //First check if input is correct (still need to do...)

            //return the coordinates cordinates...
            Coordinates _cords = new Coordinates() 
            {
                    xCord = _services.GetXCordinates(_userInput), 
                    yCord = _services.GetYCordinates(_userInput) 
            };

            return _cords;
        }
    }
}
