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
    
    [Route("api/[controller]")]
    [ApiController]
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
        public string Get()
        {

            return "hello";
        }

        [HttpGet("{coords}/{input}")]
        public Coordinates Get(string input)
        {

            string _userInput = input;


            //Make sure correct input using an extension method I created in Extensions.cs
            bool isValid = _userInput.isCorrectXYInput();

            if (!isValid)
            {
                Coordinates _badInput = new Coordinates();
                _badInput.results = "Invalid Input";
                return _badInput;

            }

            //return the coordinates cordinates...
            Coordinates _cords = new Coordinates()
            {
                xCord = _services.GetXCordinates(_userInput),
                yCord = _services.GetYCordinates(_userInput),
                results = "success"
            };

            return _cords;
        }
    }
}
