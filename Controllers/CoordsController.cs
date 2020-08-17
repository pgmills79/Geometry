using Geometry.Models;
using Geometry.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Geometry.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoordsController : ControllerBase
    {
        //this is our service (dependency injection)
        private readonly IGeometryServices _services;


        public CoordsController(IGeometryServices services)
        {     
            //inject our Geometry service into this controller
            _services = services;
        }

        [HttpGet]
        public string Get()     
        {

                return "hello";
        }

        [HttpGet("{input}")]
        public Coordinates Get(string input)
        {

            string _userInput = input;

            //Make sure correct input using an extension method I created in Extensions.cs
            bool isValid = _userInput.isValidXYInput();

            if (!isValid)
            {
                Coordinates _badInput = new Coordinates();
                _badInput.Results = HttpStatusCode.BadRequest.ToString();
                return _badInput;

            }


            //return the coordinates cordinates...
            Coordinates _cords = new Coordinates()
            {
                RightAngle = _services.GetCoordsRightAngle(_userInput),
                HorizontalPointA = _services.GetCoordsHorizontalA(_userInput),
                VerticalPointB = _services.GetCoordsVerticalB(_userInput),
                Results = HttpStatusCode.OK.ToString()
            };

            return _cords;
        }

    }
}
