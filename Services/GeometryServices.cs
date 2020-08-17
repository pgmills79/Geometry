using Geometry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Geometry.Services
{
    public class GeometryServices : IGeometryServices
    {
        //constant to calculate the 10 pixels (+/-)
        private const int PIXEL_SPACING = 10;
        //constant for even number divide/multiply by 2
        private const int EVEN_NUMBER_CALC = 2;

        private int GetXCordinates(string userInput) 
        {
        
            int _xCord = 0;
            //if this is divisible by 2 then its hypotenus on the bottom
            if (userInput.isEvenNumber())
            {
                _xCord = (getNumberChosen(userInput) / EVEN_NUMBER_CALC) * PIXEL_SPACING;  //10 pixels over to get to the point
                return _xCord;
            }

            //since we know this is odd number then we can use the odd number mappings for 
            //x cordinates (if this was an even number it would have already exited this method)
            Dictionary<int, int> _xMapping = new Dictionary<int, int>();
            _xMapping.Add(1, 0);
            _xMapping.Add(3, 10);
            _xMapping.Add(5, 20);
            _xMapping.Add(7, 30);
            _xMapping.Add(9, 40);
            _xMapping.Add(11, 50);

            return _xMapping[getNumberChosen(userInput)];

           
        }

        private int GetYCordinates(string userInput)
        {

            Dictionary<string, int> _yMapping = new Dictionary<string, int>();
            _yMapping.Add("A", 60);
            _yMapping.Add("B", 50);
            _yMapping.Add("C", 40);
            _yMapping.Add("D", 30);
            _yMapping.Add("E", 20);
            _yMapping.Add("F", 10);
            
            int _yCord = 0;

            //if this is divisible by 2 then its hypotenus on the bottom
            if (userInput.isEvenNumber())
            {
                _yCord = (Convert.ToInt16(_yMapping[getLetterChosen(userInput)]));
                return _yCord;
            }

            //since we knw this is odd numbers then we can use the odd number mappings for 
            //y cordinates (if this was an even number it would have already exited this method)
            _yMapping = new Dictionary<string, int>();
            _yMapping.Add("A", 50);
            _yMapping.Add("B", 40);
            _yMapping.Add("C", 30);
            _yMapping.Add("D", 20);
            _yMapping.Add("E", 10);
            _yMapping.Add("F", 0);

            return _yMapping[getLetterChosen(userInput)];

        }

        public Dictionary<string, int> GetCoordsRightAngle(string userInput) 
        {
            Dictionary<string, int> _rightAngle = new Dictionary<string, int>();

            _rightAngle.Add("x", GetXCordinates(userInput));
            _rightAngle.Add("y", GetYCordinates(userInput));

            return _rightAngle;
        }

        public Dictionary<string, int> GetCoordsHorizontalA(string userInput) 
        {
          
            Dictionary<string, int> _HorizontalA = new Dictionary<string, int>();

            //GET X cordinates for the horizontal plane
            if (userInput.isEvenNumber())
            {
                _HorizontalA.Add("x", (GetCoordsRightAngle(userInput)["x"]) - PIXEL_SPACING);
            }
            else
            {
                _HorizontalA.Add("x", GetCoordsRightAngle(userInput)["x"] + PIXEL_SPACING);  
            }

            //y mapping would be the same as the right angle
            _HorizontalA.Add("y", GetCoordsRightAngle(userInput)["y"]);


            return _HorizontalA;            
        
        
        }
        public Dictionary<string, int> GetCoordsVerticalB(string userInput) 
        {

            Dictionary<string, int> _VerticalB = new Dictionary<string, int>();

            //GET x cordinates for the horizontal plane
            if (userInput.isEvenNumber())
            {
                _VerticalB.Add("x", (GetCoordsRightAngle(userInput)["x"]));
                //y mapping would be the same as the right angle
                _VerticalB.Add("y", GetCoordsRightAngle(userInput)["y"] - PIXEL_SPACING);
            }
            else
            {
                _VerticalB.Add("x", GetCoordsRightAngle(userInput)["x"]);
                _VerticalB.Add("Y", GetCoordsRightAngle(userInput)["y"] + PIXEL_SPACING);
            }            


            return _VerticalB;

        }

        private int getNumberChosen(string userInput)
        {
            return Convert.ToInt16(userInput.Substring(1, userInput.Length - 1));
        }

        private string getLetterChosen(string userInput)
        {
            return userInput.Substring(0, 1);
        }

        public Dictionary<string, List<string>> GetAllVertexes(string userInput)
        {
            //regular expression pattern to get all the matches form the user input
            //in format of (( or [ )xx,xx () or ])
            var pattern = @"(\(|\[)(.*?)(\)|\])";  
            var query = userInput;
            List<Match> _matches = Regex.Matches(query, pattern).ToList();

            List<string> _v1 = RemoveUnwantedCharacters(_matches[0].Value).Split(',').ToList();
            List<string> _v2 = RemoveUnwantedCharacters(_matches[1].Value).Split(',').ToList();
            List<string> _v3 = RemoveUnwantedCharacters(_matches[2].Value).Split(',').ToList();

            Dictionary<string, List<string>> _vertexes = new Dictionary<string, List<string>>();

            _vertexes.Add(

                "V1",
                _v1
            );

            _vertexes.Add(

                "V2",
                _v2
            );

            _vertexes.Add(

               "V3",
               _v3
           );

            return _vertexes;

        }

        public string GetTriangleSector(string userInput)
        {
            //the GetAllVertexes gets all the vertexes from suer input.  
            //I have key/values for each and a list of the x/y coord for all 3
            List<string> _firstVertex = GetAllVertexes(userInput)["V1"];
            List<string> _secondVertex = GetAllVertexes(userInput)["V2"];
            List<string> _thirdVertex = GetAllVertexes(userInput)["V3"];

            //need to store column and row info
            int _column = 0;
            string _row = string.Empty;

            Sector _sector = new Sector();

            //is it bottom triangle
            bool _isBottomTriangle = Convert.ToInt16(_secondVertex[1]) > Convert.ToInt16(_firstVertex[1]);

            if (_isBottomTriangle)  //so we would know that the number is odd
            {  //odd number columns


                _column = _sector.XCoords
                .Where(
                        a => a.Value.Equals(Convert.ToInt16(_firstVertex[0]))
                        &
                        //since we know this is an odd number it is NOT divisble by 2
                        a.Key % 2 != 0
                      )
                .Select(a => a.Key)
                .FirstOrDefault<int>();

                _row = _sector.YCoords
                .Where(
                        a => a.Value.Equals(Convert.ToInt16(_firstVertex[1]))
                        &
                        //since we know this is an odd number it is NOT divisble by 2
                        Convert.ToInt16(a.Key.Substring(1, 1)) % EVEN_NUMBER_CALC != 0  
                      )
                .Select(a => a.Key.Substring(0, 1))
                .FirstOrDefault<string>();

            }
            else  //even number columns
            {
                _column = _sector.XCoords
                 .Where(
                         a => a.Value.Equals(Convert.ToInt16(_firstVertex[0]))
                         &
                         //since we know this is an even number it IS divisble by 2
                         a.Key % EVEN_NUMBER_CALC == 0
                       )
                 .Select(a => a.Key)
                 .FirstOrDefault<int>();

                _row = _sector.YCoords
                   .Where(
                           a => a.Value.Equals(Convert.ToInt16(_firstVertex[1]))
                           &
                           //since we know this is an even number it IS divisble by 2
                           Convert.ToInt16(a.Key.Substring(1, 1)) % EVEN_NUMBER_CALC == 0
                         )
                   .Select(a => a.Key.Substring(0, 1))  //the row value should only be the first character
                   .FirstOrDefault<string>();

            }


            return "You chose: " + _row + _column.ToString();

        }

        private string RemoveUnwantedCharacters(string stringToUpdate)
        {

            string _newStringValue = stringToUpdate
                                    .Replace("(", string.Empty)
                                    .Replace("[", string.Empty)
                                    .Replace(")", string.Empty)
                                    .Replace("]", string.Empty);

            return _newStringValue;


        }


    }
}
